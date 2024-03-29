using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace tienda
{
    public partial class Previsualisacion_imagen : Form
    {
        byte[] imagentemporal;
        public Previsualisacion_imagen(byte[] imagen, string CambiarImagen)
        {
            InitializeComponent();
            try
            {
                imagentemporal = imagen;
                
                if(CambiarImagen == "si")
                {
                    using (MemoryStream ms = new MemoryStream(imagen))
                    {
                        Image image = Image.FromStream(ms);

                        // Mostrar la imagen en el PictureBox
                        pictureBox1.Image = image;
                        //pictureBox1.Image = Image.FromFile(imagen);
                        BtnGuardar.Text = "Aceptar";
                        BtnCancelar.Enabled = false;
                    }
                    
                    //BtnCancelar.Enabled = false;
                    //BtnCambiarImagen.Enabled = true;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream(imagen))
                    {
                        Image image = Image.FromStream(ms);

                        // Mostrar la imagen en el PictureBox
                        pictureBox1.Image = image;
                        //pictureBox1.Image = Image.FromFile(imagen);
                        BtnGuardar.Text = "Guardar";
                        BtnAbriConFotos.Enabled = false;
                        //pictureBox1.Image = Image.FromFile(imagen);

                    }
                    
                    //BtnCancelar.Enabled = true;
                }
            }
            catch(OutOfMemoryException)
            {
                MessageBox.Show("Solo puede elegir archivos con la extencion:\n.jpg, .jpeg, .png", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnGuardar.Enabled = false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
         {
            if(BtnCancelar.Enabled == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Yes;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        string nuevaruta;

        private void BtnCambiarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                nuevaruta = ofd.FileName;
                pictureBox1.Image = Image.FromFile(nuevaruta);
                BtnCancelar.Enabled = true;
                BtnAbriConFotos.Enabled = false;
            }
        }

        public string ObtenerNuevaRuta()
        {
            return nuevaruta;
        }

        string imagenborrar;

        
        private void BtnAbriConFotos_Click(object sender, EventArgs e)
        {
            BtnAbriConFotos.Enabled = false;
            string carpetatemporal = Path.GetTempPath();
            string rutatemporalimagen = Path.Combine(carpetatemporal, "imagentemporal.jpg");
            File.WriteAllBytes(rutatemporalimagen, imagentemporal);
            imagenborrar = rutatemporalimagen;
            Borrarimagen.Start();
            Process.Start(rutatemporalimagen);

        }

        private void Borrarimagen_Tick(object sender, EventArgs e)
        {
            if(Process.GetProcessesByName("PhotosApp").Length == 0)//PhotosService
            {
                File.Delete(imagenborrar);
                BtnAbriConFotos.Enabled = true;
                Borrarimagen.Stop();
            }
        }
    }
}
