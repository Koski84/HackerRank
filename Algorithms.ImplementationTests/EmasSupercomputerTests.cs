using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Algorithms.Implementation.EmasSupercomputer;

namespace Algorithms.Implementation.Tests
{
    [TestClass()]
    public class EmasSupercomputerTests
    {
        [TestMethod()]
        public void DadosNyMConstruyeMatrizNxM()
        {
            int n = 5;
            int m = 3;

            EmasSupercomputer.Init(n, m);

            Assert.AreEqual(15, EmasSupercomputer.Matrix.Length);
        }

        [TestMethod()]
        public void DadaUnaLineaRellenaEsaLinea()
        {
            int linea = 1;
            string datosLinea = "GBB";
            EmasSupercomputer.Init(3, 3);

            EmasSupercomputer.FillLine(linea, datosLinea);

            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 0]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[1, 1]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[1, 2]);
        }

        [TestMethod()]
        public void DadaTodasLineasRellenaMatriz()
        {
            string datosLinea0 = "GBG";
            string datosLinea1 = "GGG";
            string datosLinea2 = "GGB";
            EmasSupercomputer.Init(3, 3);

            EmasSupercomputer.FillLine(0, datosLinea0);
            EmasSupercomputer.FillLine(1, datosLinea1);
            EmasSupercomputer.FillLine(2, datosLinea2);

            Assert.AreEqual(0, EmasSupercomputer.Matrix[0, 0]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[0, 1]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[0, 2]);

            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 0]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 1]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 2]);

            Assert.AreEqual(0, EmasSupercomputer.Matrix[2, 0]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[2, 1]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[2, 2]);
        }

        private static void InicializarSampleMatrix()
        {
            EmasSupercomputer.Init(5, 5);
            EmasSupercomputer.FillLine(0, "BGGGG");
            EmasSupercomputer.FillLine(1, "BGGBG");
            EmasSupercomputer.FillLine(2, "GGGGG");
            EmasSupercomputer.FillLine(3, "GBGGG");
            EmasSupercomputer.FillLine(4, "GGGGB");
        }

        [TestMethod()]
        public void MatrizGGResultado1()
        {
            EmasSupercomputer.Init(1, 2);
            EmasSupercomputer.FillLine(0, "GG");

            int res = EmasSupercomputer.Process();

            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void Matriz4x4GResultado5()
        {
            EmasSupercomputer.Init(4, 4);
            EmasSupercomputer.FillLine(0, "GGGG");
            EmasSupercomputer.FillLine(1, "GGGG");
            EmasSupercomputer.FillLine(2, "GGGG");
            EmasSupercomputer.FillLine(3, "GGGG");

            int res = EmasSupercomputer.Process();

            Assert.AreEqual(5, res);
        }

        [TestMethod()]
        public void SampleMatrixPlus22TieneSuperficie9()
        {
            InicializarSampleMatrix();

            int area = EmasSupercomputer.SetPlusAndGetHisMaximumArea(2, 2);

            Assert.AreEqual(9, area);
        }

        [TestMethod()]
        public void SampleMatrixPlus33TieneSuperficie5()
        {
            InicializarSampleMatrix();

            int area = EmasSupercomputer.SetPlusAndGetHisMaximumArea(3, 3);

            Assert.AreEqual(5, area);
        }

        [TestMethod()]
        public void AlEstablecerUnPlusLasCeldasQueOcupaCuentanComoBadExceptoLaCentralQueContieneElArea()
        {
            InicializarSampleMatrix();

            EmasSupercomputer.SetPlusAndGetHisMaximumArea(3, 3);

            Assert.AreEqual(5, EmasSupercomputer.Matrix[3, 3]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[2, 3]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[4, 3]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[3, 2]);
            Assert.AreEqual(-1, EmasSupercomputer.Matrix[3, 4]);
        }

        [TestMethod()]
        public void AlEliminarUnPlusTodoQuedaComoEstaba()
        {
            EmasSupercomputer.Init(3, 3);
            EmasSupercomputer.Matrix[1, 1] = 5;
            EmasSupercomputer.Matrix[0, 1] = -1;
            EmasSupercomputer.Matrix[2, 1] = -1;
            EmasSupercomputer.Matrix[1, 0] = -1;
            EmasSupercomputer.Matrix[1, 2] = -1;

            EmasSupercomputer.RemovePlus(1, 1);

            Assert.AreEqual(0, EmasSupercomputer.Matrix[0, 1]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 1]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[2, 1]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 0]);
            Assert.AreEqual(0, EmasSupercomputer.Matrix[1, 2]);
        }

        [TestMethod()]
        public void SampleMatrixResultado9()
        {
            InicializarSampleMatrix();

            int res = EmasSupercomputer.Process();

            Assert.AreEqual(9, res);
        }
    }
}