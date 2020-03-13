using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace piano_man
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WaveOut waveOut;
        private MixingSampleProvider mixer;

        public MainWindow()
        {
            InitializeComponent();

            waveOut = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;    
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.IsRepeat) return;

            if(e.Key == Key.Z)
            {
                Button_Click(this, null);
            }

            if (e.Key == Key.S) 
            {
                BtnDoSos_Click(this, null);
            }

            if (e.Key == Key.X)
            {
                BtnRe_Click(this, null);
            }

            if (e.Key == Key.D)
            {
                BtnReSos_Click(this, null);
            }

            if (e.Key == Key.C)
            {
                BtnMi_Click(this, null);
            }

            if (e.Key == Key.V)
            {
                BtnFa_Click(this, null);
            }

            if (e.Key == Key.G)
            {
                BtnFaSos_Click(this, null);
            }

            if (e.Key == Key.B)
            {
                BtnSol_Click(this, null);
            }

            if (e.Key == Key.H)
            {
                BtnSolSos_Click(this, null);
            }

            if (e.Key == Key.N)
            {
                BtnLa_Click(this, null);
            }

            if (e.Key == Key.J)
            {
                BtnLaSos_Click(this, null);
            }

            if (e.Key == Key.M)
            {
                BtnSi_Click(this, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nota_do = new SignalGenerator(44100, 1)
            {
                Gain = 0.5,
                Frequency = 261.6,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(250));
            mixer.AddMixerInput(nota_do);
        }

        private void BtnDoSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_doSos = DoModificado(1.0 / 12.0);
            mixer.AddMixerInput(nota_doSos);
        }

        private ISampleProvider NotaDo()
        {
            var nota_do = new SignalGenerator(44100, 1)
            {
                Gain = 0.5,
                Frequency = 261.6,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(250));
            return nota_do;
        }

        private void BtnRe_Click(object sender, RoutedEventArgs e)
        {
            var nota_re = DoModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_re);
        }

        private SmbPitchShiftingSampleProvider DoModificado(double exponente)
        {
            var nota_do = NotaDo();
            var nota_modificada = new SmbPitchShiftingSampleProvider(nota_do);
            nota_modificada.PitchFactor = (float)Math.Pow(2.0, exponente);

            return nota_modificada;
        }

        private void BtnReSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_ReSos = DoModificado(3.0/12.0);
            mixer.AddMixerInput(nota_ReSos);
        }

        private void BtnMi_Click(object sender, RoutedEventArgs e)
        {
            var nota_Mi = DoModificado(4.0/12.0);
            mixer.AddMixerInput(nota_Mi);
        }

        private void BtnFa_Click(object sender, RoutedEventArgs e)
        {
            var nota_Fa = DoModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_Fa);
        }

        private void BtnFaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_FaSos = DoModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_FaSos);
        }

        private void BtnSol_Click(object sender, RoutedEventArgs e)
        {
            var nota_Sol = DoModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_Sol);
        }

        private void BtnSolSos_Click(object sender, RoutedEventArgs e)
        {
            var notaSolSos = DoModificado(8.0 / 12.0);
            mixer.AddMixerInput(notaSolSos);
        }

        private void BtnLa_Click(object sender, RoutedEventArgs e)
        {
            var nota_La = DoModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_La);
        }

        private void BtnLaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_LaSos = DoModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_LaSos);
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            var nota_Si = DoModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_Si);
        }
    }
}
