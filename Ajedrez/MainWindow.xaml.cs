using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wincon = System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Caca = System.Drawing;

namespace Ajedrez {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        const int gridSize = 30;
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            CreateBoard();
            CreatePieces();
        }

        private void CreateBoard() {
            Wincon.RowDefinition[] cellW = new Wincon.RowDefinition[8];
            Wincon.ColumnDefinition[] cellH = new Wincon.ColumnDefinition[8];
            Wincon.Grid[] gridArr = new Wincon.Grid[64];
            int color = 0;
            int cycle = 1;
            int num = 0;

            for (int i = 1; i <= 64; i++) {
                Wincon.Grid grid = new Wincon.Grid {
                    Width = 600 / 8,
                    Height = 600 / 8,
                    Name = "cell" + i + 1.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = ColorCell(color),
                };

                gridArr[i - 1] = grid;

                color++;
                if (i == 8 * cycle) {
                    color++;
                    cycle++;
                }
            }

            for (int j = 0; j < 8; j++) {
                for (int k = 0; k < 8; k++) {
                    
                    Wincon.Grid.SetColumn(gridArr[num], j);
                    Wincon.Grid.SetRow(gridArr[num], k);
                    checker.Children.Add(gridArr[num]);
                    num++;

                }
            } 
        }

        private void CreatePieces() {
            // Ruta de las imágenes
            string wpPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/pawnWhite.png";
            string bpPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/pawnBlack.png";
            string wkPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/kingWhite.png";
            string bkPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/kingBlack.png";
            string wqPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/queenWhite.png";
            string bqPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/queenBlack.png";
            string wrPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/rookWhite.png";
            string brPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/rookBlack.png";
            string wknPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/knightWhite.png";
            string bknPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/knightBlack.png";
            string wbPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/bishopWhite.png";
            string bbPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/bishopBlack.png";


            // Crear peones blancos
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapWP = new BitmapImage(new Uri(wpPath));

                Wincon.Image imageWP = new Wincon.Image {
                    Name = "WhitePawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapWP
                };

                Wincon.Grid.SetColumn(imageWP, i);
                Wincon.Grid.SetRow(imageWP, 6);
                imageWP.MouseDown += Grid_MouseDown;
                pieces.Children.Add(imageWP);
            }

            // Crear peones negros
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapBP = new BitmapImage(new Uri(bpPath));

                Wincon.Image imageBP = new Wincon.Image {
                    Name = "BlackPawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapBP
                };

                Wincon.Grid.SetColumn(imageBP, i);
                Wincon.Grid.SetRow(imageBP, 1);
                imageBP.MouseDown += Grid_MouseDown;
                pieces.Children.Add(imageBP);
            }

            //Crear rey negro
            BitmapImage bitmapBK = new BitmapImage(new Uri(bkPath));

            Wincon.Image imageBK = new Wincon.Image {
                Name = "BlackKing",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBK
            };
            Wincon.Grid.SetColumn(imageBK, 4);
            Wincon.Grid.SetRow(imageBK, 0);
            imageBK.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBK);

            //Crear rey blanco
            BitmapImage bitmapWK = new BitmapImage(new Uri(wkPath));

            Wincon.Image imageWK = new Wincon.Image {
                Name = "WhiteKing",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWK
            };
            Wincon.Grid.SetColumn(imageWK, 4);
            Wincon.Grid.SetRow(imageWK, 7);
            imageWK.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWK);

            //Crear reina negra
            BitmapImage bitmapBQ = new BitmapImage(new Uri(bqPath));

            Wincon.Image imageBQ = new Wincon.Image {
                Name = "BlackQueen",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBQ
            };
            Wincon.Grid.SetColumn(imageBQ, 3);
            Wincon.Grid.SetRow(imageBQ, 0);
            imageBQ.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBQ);

            //Crear reina blanca
            BitmapImage bitmapWQ = new BitmapImage(new Uri(wqPath));

            Wincon.Image imageWQ = new Wincon.Image {
                Name = "WhiteQueen",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWQ
            };
            Wincon.Grid.SetColumn(imageWQ, 3);
            Wincon.Grid.SetRow(imageWQ, 7);
            imageWQ.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWQ);

            //Crear alfiles negros
            BitmapImage bitmapBB = new BitmapImage(new Uri(bbPath));

            Wincon.Image imageBB = new Wincon.Image {
                Name = "BlackBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBB
            };
            Wincon.Grid.SetColumn(imageBB, 2);
            Wincon.Grid.SetRow(imageBB, 0);
            imageBB.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBB);

            bitmapBB = new BitmapImage(new Uri(bbPath));

            imageBB = new Wincon.Image {
                Name = "BlackBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBB
            };
            Wincon.Grid.SetColumn(imageBB, 5);
            Wincon.Grid.SetRow(imageBB, 0);
            imageBB.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBB);

            //Crear alfiles blancos
            BitmapImage bitmapWB = new BitmapImage(new Uri(wbPath));

            Wincon.Image imageWB = new Wincon.Image {
                Name = "WhiteBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWB
            };
            Wincon.Grid.SetColumn(imageWB, 2);
            Wincon.Grid.SetRow(imageWB, 7);
            imageWB.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWB);

            bitmapWB = new BitmapImage(new Uri(wbPath));

            imageWB = new Wincon.Image {
                Name = "WhiteBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWB
            };
            Wincon.Grid.SetColumn(imageWB, 5);
            Wincon.Grid.SetRow(imageWB, 7);
            imageWB.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWB);

            //Crear caballeros negros
            BitmapImage bitmapBKn = new BitmapImage(new Uri(bknPath));

            Wincon.Image imageBKn = new Wincon.Image {
                Name = "BlackKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBKn
            };
            Wincon.Grid.SetColumn(imageBKn, 1);
            Wincon.Grid.SetRow(imageBKn, 0);
            imageBKn.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBKn);

            bitmapBKn = new BitmapImage(new Uri(bknPath));

            imageBKn = new Wincon.Image {
                Name = "BlackKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBKn
            };
            Wincon.Grid.SetColumn(imageBKn, 6);
            Wincon.Grid.SetRow(imageBKn, 0);
            imageBKn.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBKn);

            //Crear caballeros blancos
            BitmapImage bitmapWKn = new BitmapImage(new Uri(wknPath));

            Wincon.Image imageWKn = new Wincon.Image {
                Name = "WhiteKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWKn
            };
            Wincon.Grid.SetColumn(imageWKn, 1);
            Wincon.Grid.SetRow(imageWKn, 7);
            imageWKn.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWKn);

            bitmapWKn = new BitmapImage(new Uri(wknPath));

            imageWKn = new Wincon.Image {
                Name = "WhiteKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWKn
            };
            Wincon.Grid.SetColumn(imageWKn, 6);
            Wincon.Grid.SetRow(imageWKn, 7);
            imageWKn.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWKn);

            //Crear torres negras
            BitmapImage bitmapBR = new BitmapImage(new Uri(brPath));

            Wincon.Image imageBR = new Wincon.Image {
                Name = "BlackRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBR
            };
            Wincon.Grid.SetColumn(imageBR, 0);
            Wincon.Grid.SetRow(imageBR, 0);
            imageBR.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBR);

            bitmapBR = new BitmapImage(new Uri(brPath));

            imageBR = new Wincon.Image {
                Name = "BlackRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBR
            };
            Wincon.Grid.SetColumn(imageBR, 7);
            Wincon.Grid.SetRow(imageBR, 0);
            imageBR.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageBR);

            //Crear torres blancas
            BitmapImage bitmapWR = new BitmapImage(new Uri(wrPath));

            Wincon.Image imageWR = new Wincon.Image {
                Name = "WhiteRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWR
            };
            Wincon.Grid.SetColumn(imageWR, 0);
            Wincon.Grid.SetRow(imageWR, 7);
            imageWR.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWR);

            bitmapWR = new BitmapImage(new Uri(wrPath));

            imageWR = new Wincon.Image {
                Name = "WhiteRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWR
            };
            Wincon.Grid.SetColumn(imageWR, 7);
            Wincon.Grid.SetRow(imageWR, 7);
            imageWR.MouseDown += Grid_MouseDown;
            pieces.Children.Add(imageWR);
        }


        private static SolidColorBrush ColorCell(int i) {
            SolidColorBrush color = new SolidColorBrush();
            if ((i + 1) % 2 == 1)
                 color = new System.Windows.Media.
                    SolidColorBrush(System.Windows.Media.Colors.Beige);
            else
                 color = new System.Windows.Media.
                    SolidColorBrush(System.Windows.Media.Colors.DarkGreen);
            return color;
        }

        private void Image_MouseDown(object sender, MouseEventArgs e) {
            if (sender is Wincon.Image image) {
                MessageBox.Show("Haz hecho click en el grid : " + image.Name );
            }
        }
    }
}
