using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjJogoDamaModelo
{
    public partial class frmJogoVelha : Form
    {
        private int _size = 80;
        private List<int> _lstPecaBranca = new List<int>();
        private List<int> _lstPecaPreta = new List<int>();
        private List<String> _lstTabuleiro = new List<string>();
        private int _NrClick = 0;
        private int _OrigemNrCasa = -1;
        private int _OrigemCasaX = -1;
        private int _OrigemCasaY = -1;
        private String _Jogador = "";
        private List<int> _lstBrancaEsquerdoValida = new List<int>();
        private List<int> _lstBrancaDireitoValida = new List<int>();
        private List<int> _lstPretaEsquerdoValida = new List<int>();
        private List<int> _lstPretaDireitoValida = new List<int>();

        public frmJogoVelha()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            SolidBrush _Branco = new SolidBrush(Color.White);
            SolidBrush _Preto = new SolidBrush(Color.Black);

            //Desenhando o Tabuleiro
            Graphics _Tabuleiro = this.CreateGraphics();
            for (int l = 0; l < 8; l++)
            {
                for (int c = 0; c < 8; c++)
                {

                    if (((l % 2 == 0) && (c % 2 == 1)) || ((l % 2 == 1) && (c % 2 == 0)))
                    {
                        _Tabuleiro.FillRectangle(_Preto, new Rectangle(c * _size, l * _size, _size, _size));
                    }
                    else
                    {
                        _Tabuleiro.FillRectangle(_Branco, new Rectangle(c * _size, l * _size, _size, _size));
                    }

                }
            }

            //Desenhando a peças brancas na posição inicial.
            int _cont = 0;
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (((l % 2 == 0) && (c % 2 == 1)) || ((l % 2 == 1) && (c % 2 == 0)))
                    {
                        pPecaBranca(c * _size, l * _size);
                        _lstPecaBranca.Add(_cont);
                        _cont++;

                    }

                }
            }

            //Desenhando a peças pretas na posição inicial.
            _cont = 31;
            for (int l = 7; l > 4; l--)
            {
                for (int c = 7; c >= 0; c--)
                {
                    if (((l % 2 == 0) && (c % 2 == 1)) || ((l % 2 == 1) && (c % 2 == 0)))
                    {
                        pPecaPreta(c * _size, l * _size);
                        _lstPecaPreta.Add(_cont);
                        _cont--;
                    }

                }
            }

            for (int i = 0; i < 12; i++)
            {
                _lstTabuleiro.Add("Branco");
            }

            for (int i = 12; i < 20; i++)
            {
                _lstTabuleiro.Add("");
            }

            for (int i = 20; i < 32; i++)
            {
                _lstTabuleiro.Add("Preto");
            }

            _Jogador = "Branco";

            _PreencheListaValida();

        }

        private void pPecaBranca(int _PosicaoX, int _PosicaoY)
        {
            SolidBrush _Cor = new SolidBrush(Color.Pink);

            Graphics _Tabuleiro = this.CreateGraphics();
            _Tabuleiro.FillEllipse(_Cor, new Rectangle(_PosicaoX, _PosicaoY, _size, _size));
        }

        private void pPecaPreta(int _PosicaoX, int _PosicaoY)
        {
            SolidBrush _Cor = new SolidBrush(Color.Brown);

            Graphics _Tabuleiro = this.CreateGraphics();
            _Tabuleiro.FillEllipse(_Cor, new Rectangle(_PosicaoX, _PosicaoY, _size, _size));
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            int _CasaX;
            int _CasaY;
            Graphics _Tabuleiro = this.CreateGraphics();

            _CasaX = Convert.ToInt16(e.X / _size);
            _CasaY = Convert.ToInt16(e.Y / _size);

            int _NroCasa = -1;

            if (_CasaY % 2 == 0)
            {
                if (_CasaX % 2 == 1)
                {
                    _NroCasa = (_CasaY * 4) + ((_CasaX - 1) / 2);

                }
                else
                {
                    return;
                }
            }
            else
            {
                if (_CasaX % 2 == 0) {
                    _NroCasa = (_CasaY * 4) + (_CasaX / 2);
                }
                else
                {
                    return;
                }
            }



            //Verificando se é o 1º ou o 2º Click do Mouse
            if (_NrClick == 0)
            {

                if (!_Jogador.Equals(_lstTabuleiro[_NroCasa]))
                {
                    MessageBox.Show("Não é sua vez de jogar !!!");
                    return;
                }

                _NrClick = 1;

                _OrigemNrCasa = _NroCasa;
                _OrigemCasaX = _CasaX;
                _OrigemCasaY = _CasaY;

            if (!_Jogador.Equals(_lstTabuleiro[_NroCasa]))
            {
                MessageBox.Show("Não é sua vez de Jogar !!!");
                return;
            }
            }
            else if (_NrClick == 1)
            {

                _NrClick = 2;

            }

            if (((_CasaY % 2 == 0) && (_CasaX % 2 == 1)) || ((_CasaY % 2 == 1) && (_CasaX % 2 == 0)))
            {
                SolidBrush _Cor;

                if (_NrClick == 1)
                {

                    //Será executado essa parte quando for o Primeiro Click
                    
                    //Verifica se a casa onde cliquei esta vazia
                    if ("".Equals(_lstTabuleiro[_NroCasa]))
                    {
                        MessageBox.Show("Escolha outro Buraco");

                        //Zera a Jogada
                        _NrClick = 0;
                    }
                    else
                    {
                        //Se a casa não tiver vazia ele pinta de cinza para dar a sensação de seleção
                        _Cor = new SolidBrush(Color.Gray);
                        _Tabuleiro.FillEllipse(_Cor, new Rectangle(_CasaX * _size, _CasaY * _size, _size, _size));

                    }

                }
                else
                {

                    //Será executado essa parte quando for o Segundo Click

                    //Se a casa Selecionada tem alguma peça
                    if (!"".Equals(_lstTabuleiro[_NroCasa]))
                    {

                        //Da a Mensagem
                        MessageBox.Show("Já existe uma peça nessa casa");

                        //Verifica qual é a cor que eu selecionei
                        if ("Branco".Equals(_lstTabuleiro[_OrigemNrCasa]))
                        {
                            _Cor = new SolidBrush(Color.Pink);

                        }
                        else 
                        {
                            _Cor = new SolidBrush(Color.Brown);
                        }

                        _Tabuleiro.FillEllipse(_Cor, new Rectangle(_OrigemCasaX * _size, _OrigemCasaY * _size, _size, _size));
                        _NrClick = 0;

                    }
                    else
                    {

                        if ("Preto".Equals(_Jogador))
                        {
                            if ((_lstPretaDireitoValida[_OrigemNrCasa] != _NroCasa) && (_lstPretaEsquerdoValida[_OrigemNrCasa] != _NroCasa))
                            {
                                MessageBox.Show("Essa jogada não é válida");
                                return;
                            }
                        }
                        else
                        {
                            if ((_lstBrancaDireitoValida[_OrigemNrCasa] != _NroCasa) && (_lstBrancaEsquerdoValida[_OrigemNrCasa] != _NroCasa))
                            {
                                MessageBox.Show("Essa jogada não é válida");
                                return;
                            }

                        }

                        //Se a casa selecionada não tiver peça.
                        //Desenha a cor na peça na nova casa

                        //Pinta de Preto a casa Antiga
                        SolidBrush _Preto = new SolidBrush(Color.Black);
                        _Tabuleiro.FillRectangle(_Preto, new Rectangle(_OrigemCasaX * _size, _OrigemCasaY * _size, _size, _size));

                        //Verifica a Cor da Peça Selecinada
                        if ("Branco".Equals(_lstTabuleiro[_OrigemNrCasa]))
                        //if (_lstTabuleiro[_OrigemNrCasa] == "Branco")
                        {
                            _Cor = new SolidBrush(Color.Pink);
                            _lstTabuleiro[_OrigemNrCasa] = "";
                            _lstTabuleiro[_NroCasa] = "Branco";

                        }else 
                        {
                            _Cor = new SolidBrush(Color.Brown);
                            _lstTabuleiro[_OrigemNrCasa] = "";
                            _lstTabuleiro[_NroCasa] = "Preto";
                        }
                       
                        _OrigemNrCasa = -1;
                        _OrigemCasaX = -1;
                        _OrigemCasaY = -1;

                        _NrClick = 0;

                        _Tabuleiro.FillEllipse(_Cor, new Rectangle(_CasaX * _size, _CasaY * _size, _size, _size));

                        if (_Jogador.Equals("Branco"))
                        {
                            _Jogador = "Preto";
                        }
                        else
                        {
                            _Jogador = "Branco";
                        }

                    }


                }


            }


        }

        private void btnDetalhe_Click(object sender, EventArgs e)
        {

            frmDetalhe _Detalhe = new frmDetalhe();

            for (int i = 0; i < _lstPecaBranca.Count; i++)
            {
                _Detalhe.lstBranco.Items.Add(_lstPecaBranca[i]);
            }

            for (int i = 0; i< _lstPecaPreta.Count; i++)
            {
                _Detalhe.lstPreto.Items.Add(_lstPecaPreta[i]);
            }

            for (int i = 0; i< _lstTabuleiro.Count; i++)
            {
                _Detalhe.lstTabuleiro.Items.Add(_lstTabuleiro[i]);
            }
            _Detalhe.ShowDialog();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void _PreencheListaValida()
        {

            //preenchendo brancos valisods esquerdos
            _lstBrancaEsquerdoValida.Add(4);//0
            _lstBrancaEsquerdoValida.Add(5);//1
            _lstBrancaEsquerdoValida.Add(6);//2
            _lstBrancaEsquerdoValida.Add(7);//3
            _lstBrancaEsquerdoValida.Add(-1);//4
            _lstBrancaEsquerdoValida.Add(8);//5
            _lstBrancaEsquerdoValida.Add(9);//6
            _lstBrancaEsquerdoValida.Add(10);//7
            _lstBrancaEsquerdoValida.Add(12);//8
            _lstBrancaEsquerdoValida.Add(13);//9
            _lstBrancaEsquerdoValida.Add(14);//10
            _lstBrancaEsquerdoValida.Add(15);//11
            _lstBrancaEsquerdoValida.Add(-1);//12
            _lstBrancaEsquerdoValida.Add(16);//13
            _lstBrancaEsquerdoValida.Add(17);//14
            _lstBrancaEsquerdoValida.Add(18);//15
            _lstBrancaEsquerdoValida.Add(20);//16
            _lstBrancaEsquerdoValida.Add(21);//17
            _lstBrancaEsquerdoValida.Add(22);//18
            _lstBrancaEsquerdoValida.Add(23);//19
            _lstBrancaEsquerdoValida.Add(-1);//20
            _lstBrancaEsquerdoValida.Add(24);//21
            _lstBrancaEsquerdoValida.Add(25);//22
            _lstBrancaEsquerdoValida.Add(26);//23
            _lstBrancaEsquerdoValida.Add(28);//24
            _lstBrancaEsquerdoValida.Add(29);//25
            _lstBrancaEsquerdoValida.Add(30);//26
            _lstBrancaEsquerdoValida.Add(31);//27
            _lstBrancaEsquerdoValida.Add(-1);//28
            _lstBrancaEsquerdoValida.Add(-1);//29
            _lstBrancaEsquerdoValida.Add(-1);//30
            _lstBrancaEsquerdoValida.Add(-1);//31


            //preenchendo brancos validos direitos
            _lstBrancaDireitoValida.Add(5);//0
            _lstBrancaDireitoValida.Add(6);//1
            _lstBrancaDireitoValida.Add(7);//2
            _lstBrancaDireitoValida.Add(-1);//3
            _lstBrancaDireitoValida.Add(8);//4
            _lstBrancaDireitoValida.Add(9);//5
            _lstBrancaDireitoValida.Add(10);//6
            _lstBrancaDireitoValida.Add(11);//7
            _lstBrancaDireitoValida.Add(13);//8
            _lstBrancaDireitoValida.Add(14);//9
            _lstBrancaDireitoValida.Add(15);//10
            _lstBrancaDireitoValida.Add(-1);//11
            _lstBrancaDireitoValida.Add(16);//12
            _lstBrancaDireitoValida.Add(17);//13
            _lstBrancaDireitoValida.Add(18);//14
            _lstBrancaDireitoValida.Add(19);//15
            _lstBrancaDireitoValida.Add(21);//16
            _lstBrancaDireitoValida.Add(22);//17
            _lstBrancaDireitoValida.Add(23);//18
            _lstBrancaDireitoValida.Add(-1);//19
            _lstBrancaDireitoValida.Add(24);//20
            _lstBrancaDireitoValida.Add(25);//21
            _lstBrancaDireitoValida.Add(26);//22
            _lstBrancaDireitoValida.Add(27);//23
            _lstBrancaDireitoValida.Add(29);//24
            _lstBrancaDireitoValida.Add(30);//25
            _lstBrancaDireitoValida.Add(31);//26
            _lstBrancaDireitoValida.Add(-1);//27
            _lstBrancaDireitoValida.Add(-1);//28
            _lstBrancaDireitoValida.Add(-1);//29
            _lstBrancaDireitoValida.Add(-1);//30
            _lstBrancaDireitoValida.Add(-1);//31

            // preenchendo preto esquerdo válido
            _lstPretaEsquerdoValida.Add(-1);//0
            _lstPretaEsquerdoValida.Add(-1);//1
            _lstPretaEsquerdoValida.Add(-1);//2
            _lstPretaEsquerdoValida.Add(-1);//3
            _lstPretaEsquerdoValida.Add(-1);//4
            _lstPretaEsquerdoValida.Add(0);//5
            _lstPretaEsquerdoValida.Add(1);//6
            _lstPretaEsquerdoValida.Add(2);//7
            _lstPretaEsquerdoValida.Add(4);//8
            _lstPretaEsquerdoValida.Add(5);//9
            _lstPretaEsquerdoValida.Add(6);//10
            _lstPretaEsquerdoValida.Add(7);//11
            _lstPretaEsquerdoValida.Add(-1);//12
            _lstPretaEsquerdoValida.Add(7);//13
            _lstPretaEsquerdoValida.Add(9);//14
            _lstPretaEsquerdoValida.Add(10);//15
            _lstPretaEsquerdoValida.Add(12);//16
            _lstPretaEsquerdoValida.Add(13);//17
            _lstPretaEsquerdoValida.Add(14);//18
            _lstPretaEsquerdoValida.Add(15);//19
            _lstPretaEsquerdoValida.Add(-1);//20
            _lstPretaEsquerdoValida.Add(16);//21
            _lstPretaEsquerdoValida.Add(17);//22
            _lstPretaEsquerdoValida.Add(18);//23
            _lstPretaEsquerdoValida.Add(20);//24
            _lstPretaEsquerdoValida.Add(21);//25
            _lstPretaEsquerdoValida.Add(22);//26
            _lstPretaEsquerdoValida.Add(23);//27
            _lstPretaEsquerdoValida.Add(-1);//28
            _lstPretaEsquerdoValida.Add(24);//29
            _lstPretaEsquerdoValida.Add(25);//30
            _lstPretaEsquerdoValida.Add(26);//31

            //preenchendo preto direito valido
            _lstPretaDireitoValida.Add(-1);//0
            _lstPretaDireitoValida.Add(-1);//1
            _lstPretaDireitoValida.Add(-1);//2
            _lstPretaDireitoValida.Add(-1);//3
            _lstPretaDireitoValida.Add(0);//4
            _lstPretaDireitoValida.Add(1);//5
            _lstPretaDireitoValida.Add(2);//6
            _lstPretaDireitoValida.Add(3);//7
            _lstPretaDireitoValida.Add(5);//8
            _lstPretaDireitoValida.Add(6);//9
            _lstPretaDireitoValida.Add(7);//10
            _lstPretaDireitoValida.Add(-1);//11
            _lstPretaDireitoValida.Add(8);//12
            _lstPretaDireitoValida.Add(9);//13
            _lstPretaDireitoValida.Add(10);//14
            _lstPretaDireitoValida.Add(11);//15
            _lstPretaDireitoValida.Add(13);//16
            _lstPretaDireitoValida.Add(14);//17
            _lstPretaDireitoValida.Add(15);//18
            _lstPretaDireitoValida.Add(-1);//19
            _lstPretaDireitoValida.Add(16);//20
            _lstPretaDireitoValida.Add(17);//21
            _lstPretaDireitoValida.Add(18);//22
            _lstPretaDireitoValida.Add(19);//23
            _lstPretaDireitoValida.Add(21);//24
            _lstPretaDireitoValida.Add(22);//25
            _lstPretaDireitoValida.Add(23);//26
            _lstPretaDireitoValida.Add(-1);//27
            _lstPretaDireitoValida.Add(24);//28
            _lstPretaDireitoValida.Add(25);//29
            _lstPretaDireitoValida.Add(26);//30
            _lstPretaDireitoValida.Add(27);//31
        }

    }
}
