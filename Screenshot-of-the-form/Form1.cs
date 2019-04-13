using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Screenshot_of_the_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static void SaveScreenshot(Form frm)
        {
            int recStartX = 8;  // Sol border width 
            int recStartY = 31; // Üstteki Pencere çubuğunun yüksekliği 
                                // recStartX değerinin iki katını almamın sebebi, hem solda hemde sağ tarafta 8px border olduğu için toplam 8px*2 olmasıdır.
                                // recStartX değeri ile recStartY değerinin toplanmasının sebebi, üstte pencere çubuğu 31px ve alttaki border 8px olduğundan 31px+8px olmasıdır.
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PNG | *.png|JPG | *.jpg|JPEG | *.jpeg|All files (*.*)|*.*";
            saveFile.OverwritePrompt = true;
            saveFile.FileName = string.Format(@"Thornthwaite-Grafik_{0}",DateTime.Now.Ticks);
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string WhereToSaveFile = saveFile.FileName;
                Bitmap Image = new Bitmap(frm.Width, frm.Height); // Form boyutunda bir tuval oluşturuluyor
                frm.DrawToBitmap(Image, new Rectangle(0,0,frm.Width,frm.Height)); // oluşturulan tuvale form penceresinin görüntüsü çiziliyor
                Image = Image.Clone(new Rectangle(recStartX, recStartY, Image.Size.Width - (recStartX * 2), Image.Size.Height - (recStartX + recStartY)), PixelFormat.DontCare);
                // Image değişkeninde tutulan form görüntüsü üzerinde kırpma işlemi gerçekleştiriliyor ve Image değişkenine aktarılıyor.
                Image.Save(WhereToSaveFile, ImageFormat.Png);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveScreenshot(ActiveForm);
        }
    }
}
