using System.Threading.Tasks;
using Discord.Commands;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System;
using System.IO;

namespace DiscordBot.Modules
{
    public class TR_Me : ModuleBase<SocketCommandContext>
    {
        [Command("tr_me")]
        public Task Tr_me(int opacity = 80)
        {
            object pfplock = new object();

            lock (pfplock)
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(Context.User.GetAvatarUrl(Discord.ImageFormat.Png).ToString(), "pfp.png");
                }
                Image pfp = Image.FromFile("pfp.png");
                Image overlay = Image.FromFile(@"D:\Projects\Git\DiscordBotBase-csharp\src\DiscordBot\Resources\tr_Overlay.png");
                overlay = ResizeImage(overlay, pfp.Width, pfp.Height);
                //overlay = SetImageOpacity(overlay, opacity);

                Bitmap bitmap = new Bitmap(pfp);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(SetImageOpacity(overlay, opacity), 0, 0);
                    bitmap.Save("done.png", ImageFormat.Png);
                }

                Context.Channel.SendFileAsync(@"done.png").GetAwaiter().GetResult();

                bitmap.Dispose();
                pfp.Dispose();
                overlay.Dispose();

                File.Delete("pfp.png");
                File.Delete(@"done.png");
                return ReplyAsync("Here is you new tr_endy profile picture");
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// method for changing the opacity of an image
        /// </summary>
        /// <param name="image">image to set opacity on</param>
        /// <param name="opacity">percentage of opacity</param>
        /// <returns></returns>
        public Image SetImageOpacity(Image image, int iopacity)
        {
            try
            {
                decimal opacity = (decimal)iopacity / (decimal)100;

                //create a Bitmap the size of the image provided
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    //create a color matrix object
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity
                    matrix.Matrix33 = (float)opacity;

                    //create image attributes
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}