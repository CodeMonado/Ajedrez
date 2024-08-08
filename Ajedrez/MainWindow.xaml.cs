using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Drawing = System.Drawing;
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
using Popo = System.Windows.Shapes;
using Caca = System.Drawing;
using System.Diagnostics.Metrics;


namespace Ajedrez {
    
    public partial class MainWindow : Window {
        private bool hasObject = false;
        private int turn;
        static ChessBase chessBase = new ChessBase();
        UIElement pieceImage = null;
        int[,] move = null;
        int piece = 0;
        Grid[,] gridArr = new Grid[8, 8];
        int[,] gameBoard = chessBase._newBoard;
        int[,] placeBoard = new int[8, 8];

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            turn = 1;
            CreateBoard();
            CreatePieces();
        }

        private void CreateBoard() {
            RowDefinition[] cellW = new RowDefinition[8];
            ColumnDefinition[] cellH = new ColumnDefinition[8];
            
            int num = 0;
            
            for(int i = 0; i < 8; i++) 
                for (int j = 0; j < 8; j++)
                    placeBoard[i, j] = 0;
            

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Grid grid = new Grid {
                        Width = 600 / 8,
                        Height = 600 / 8,
                        Name = "cell" + i + 1.ToString(),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    
                    grid.MouseDown += Image_MouseDown;

                    gridArr[i, j] = grid;
                    
                }
            }
            

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    
                    Grid.SetColumn(gridArr[i, j], i);
                    Grid.SetRow(gridArr[i, j], j);
                    checker.Children.Add(gridArr[i, j]);
                    num++;

                }
            }
            ResetBoard();
        }

        


        

        private void ColorMovement(int row, int col, int[,] move) {
            SolidColorBrush color = new SolidColorBrush(Colors.Cyan);

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (placeBoard[i, j] == 1) {
                        gridArr[j, i].Background = color;
                    }
                }
            }
        }

        private void ResetBoard() {
            int counter = 1;
            int cycle = 1;
            SolidColorBrush color;
            

            for (int i = 1; i <= 8; i++) {
                for (int j = 1; j <= 8; j++) {
                    counter++;
                    if (counter % 2 == 1)
                        color = new SolidColorBrush(Colors.Beige);
                    else
                        color = new SolidColorBrush(Colors.DarkGreen);
                    gridArr[i - 1, j - 1].Background = color;
                    if (counter == 9 * cycle) {
                        cycle++;
                        counter++;
                    }

                }
                
            }

            
        }

        private void Image_MouseDown(object sender, MouseEventArgs e) {

            if (sender is Image image && !hasObject) {
                hasObject = !hasObject;
                SolidColorBrush color = new SolidColorBrush();
                color = new SolidColorBrush(Colors.Blue);
                int row = Grid.GetRow(image);
                int col = Grid.GetColumn(image);
                pieceImage = image;

                switch (gameBoard[row, col]) {
                    case 1:
                        placeBoard = chessBase.WhitePawnMovement(row, col);
                        piece = 1;
                        
                        break;
                        
                    case 2 or 8:
                        placeBoard = chessBase.RookMovement(row, col);
                        piece = 2;
                        
                        break;
                    case 3 or 9:
                        placeBoard = chessBase.KnightMovement(row, col);
                        piece = 3;
                        
                        break;
                }
                if(placeBoard != null) {
                    pieces.Children.Remove(image);
                    gameBoard[row, col] = 0;
                    ColorMovement(row, col, move);
                }
                Console.Clear();
                for(int i = 0; i< 8; i++) {
                    for(int j = 0; j < 8; j++) {
                        Console.Write("[" + placeBoard[i, j] + "],");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(hasObject);
            }
            else if(sender is Grid grid && hasObject) {                
                int col = Grid.GetColumn(grid);
                int row = Grid.GetRow(grid);
                Console.WriteLine("row: " + row);
                Console.WriteLine("col: " + col);
                Console.WriteLine("piece: "+ piece);
                if (gameBoard[row, col] == 0 && placeBoard[row, col] == 1) {
                    hasObject = !hasObject;
                    gameBoard[row, col] = piece;
                    //if(pieceImage != null)
                    Grid.SetRow(pieceImage, row);
                    Grid.SetColumn(pieceImage, col);
                    pieces.Children.Add(pieceImage);
                    PrintBoard();
                    pieceImage = null;
                    move = null;
                    for (int i = 0; i < 8; i++) {
                        for (int j = 0; j < 8; j++) {
                            placeBoard[i, j] = 0;
                        }
                    }
                    ResetBoard();   
                }
                Console.WriteLine(hasObject);
                
            }
        }

        private void CreatePieces() {
            // Ruta de las imágenes
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            string projectDirectory = directoryInfo.Parent.Parent.Parent.FullName;
            string imagePath = Path.Combine(projectDirectory, "Assets");

            string wpPath = Path.Combine(imagePath, "pawnWhite.png");
            string bpPath = Path.Combine(imagePath, "pawnBlack.png");
            string wkPath = Path.Combine(imagePath, "kingWhite.png");
            string bkPath = Path.Combine(imagePath, "kingBlack.png");
            string wqPath = Path.Combine(imagePath, "queenWhite.png");
            string bqPath = Path.Combine(imagePath, "queenBlack.png");
            string wrPath = Path.Combine(imagePath, "rookWhite.png");
            string brPath = Path.Combine(imagePath, "rookBlack.png");
            string wknPath = Path.Combine(imagePath, "knightWhite.png");
            string bknPath = Path.Combine(imagePath, "knightBlack.png");
            string wbPath = Path.Combine(imagePath, "bishopWhite.png");
            string bbPath = Path.Combine(imagePath, "bishopBlack.png");


            // Crear peones blancos
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapWP = new BitmapImage(new Uri(wpPath));

                Image imageWP = new Image {
                    Name = "WhitePawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapWP
                };

                Grid.SetColumn(imageWP, i);
                Grid.SetRow(imageWP, 6);
                imageWP.MouseDown += Image_MouseDown;
                pieces.Children.Add(imageWP);
            }

            // Crear peones negros
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapBP = new BitmapImage(new Uri(bpPath));

                Image imageBP = new Image {
                    Name = "BlackPawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapBP
                };

                Grid.SetColumn(imageBP, i);
                Grid.SetRow(imageBP, 1);
                imageBP.MouseDown += Image_MouseDown;
                pieces.Children.Add(imageBP);
            }

            //Crear rey negro
            BitmapImage bitmapBK = new BitmapImage(new Uri(bkPath));

            Image imageBK = new Image {
                Name = "BlackKing",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBK
            };
            Grid.SetColumn(imageBK, 4);
            Grid.SetRow(imageBK, 0);
            imageBK.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBK);

            //Crear rey blanco
            BitmapImage bitmapWK = new BitmapImage(new Uri(wkPath));

            Image imageWK = new Image {
                Name = "WhiteKing",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWK
            };
            Grid.SetColumn(imageWK, 4);
            Grid.SetRow(imageWK, 7);
            imageWK.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWK);

            //Crear reina negra
            BitmapImage bitmapBQ = new BitmapImage(new Uri(bqPath));

            Image imageBQ = new Image {
                Name = "BlackQueen",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBQ
            };
            Grid.SetColumn(imageBQ, 3);
            Grid.SetRow(imageBQ, 0);
            imageBQ.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBQ);

            //Crear reina blanca
            BitmapImage bitmapWQ = new BitmapImage(new Uri(wqPath));

            Image imageWQ = new Image {
                Name = "WhiteQueen",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWQ
            };
            Grid.SetColumn(imageWQ, 3);
            Grid.SetRow(imageWQ, 7);
            imageWQ.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWQ);

            //Crear alfiles negros
            BitmapImage bitmapBB = new BitmapImage(new Uri(bbPath));

            Image imageBB = new Image {
                Name = "BlackBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBB
            };
            Grid.SetColumn(imageBB, 2);
            Grid.SetRow(imageBB, 0);
            imageBB.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBB);

            bitmapBB = new BitmapImage(new Uri(bbPath));

            imageBB = new Image {
                Name = "BlackBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBB
            };
            Grid.SetColumn(imageBB, 5);
            Grid.SetRow(imageBB, 0);
            imageBB.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBB);

            //Crear alfiles blancos
            BitmapImage bitmapWB = new BitmapImage(new Uri(wbPath));

            Image imageWB = new Image {
                Name = "WhiteBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWB
            };
            Grid.SetColumn(imageWB, 2);
            Grid.SetRow(imageWB, 7);
            imageWB.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWB);

            bitmapWB = new BitmapImage(new Uri(wbPath));

            imageWB = new Image {
                Name = "WhiteBishop",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWB
            };
            Grid.SetColumn(imageWB, 5);
            Grid.SetRow(imageWB, 7);
            imageWB.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWB);

            //Crear caballeros negros
            BitmapImage bitmapBKn = new BitmapImage(new Uri(bknPath));

            Image imageBKn = new Image {
                Name = "BlackKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBKn
            };
            Grid.SetColumn(imageBKn, 1);
            Grid.SetRow(imageBKn, 0);
            imageBKn.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBKn);

            bitmapBKn = new BitmapImage(new Uri(bknPath));

            imageBKn = new Image {
                Name = "BlackKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBKn
            };
            Grid.SetColumn(imageBKn, 6);
            Grid.SetRow(imageBKn, 0);
            imageBKn.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBKn);

            //Crear caballeros blancos
            BitmapImage bitmapWKn = new BitmapImage(new Uri(wknPath));

            Image imageWKn = new Image {
                Name = "WhiteKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWKn
            };
            Grid.SetColumn(imageWKn, 1);
            Grid.SetRow(imageWKn, 7);
            imageWKn.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWKn);

            bitmapWKn = new BitmapImage(new Uri(wknPath));

            imageWKn = new Image {
                Name = "WhiteKnight",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWKn
            };
            Grid.SetColumn(imageWKn, 6);
            Grid.SetRow(imageWKn, 7);
            imageWKn.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWKn);

            //Crear torres negras
            BitmapImage bitmapBR = new BitmapImage(new Uri(brPath));

            Image imageBR = new Image {
                Name = "BlackRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBR
            };
            Grid.SetColumn(imageBR, 0);
            Grid.SetRow(imageBR, 0);
            imageBR.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBR);

            bitmapBR = new BitmapImage(new Uri(brPath));

            imageBR = new Image {
                Name = "BlackRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapBR
            };
            Grid.SetColumn(imageBR, 7);
            Grid.SetRow(imageBR, 0);
            imageBR.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageBR);

            //Crear torres blancas
            BitmapImage bitmapWR = new BitmapImage(new Uri(wrPath));

            Image imageWR = new Image {
                Name = "WhiteRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWR
            };
            Grid.SetColumn(imageWR, 0);
            Grid.SetRow(imageWR, 7);
            imageWR.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWR);

            bitmapWR = new BitmapImage(new Uri(wrPath));

            imageWR = new Image {
                Name = "WhiteRook",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Source = bitmapWR
            };
            Grid.SetColumn(imageWR, 7);
            Grid.SetRow(imageWR, 7);
            imageWR.MouseDown += Image_MouseDown;
            pieces.Children.Add(imageWR);
        }

    void PrintBoard() {
            //Console.Clear();

            for(int i = 0; i < 8; i++) { 
                for(int j = 0; j < 8; j++) {
                    Console.Write("[" + gameBoard[i,j] + "],");
                }
                Console.WriteLine();
            }
        }
    }
}
