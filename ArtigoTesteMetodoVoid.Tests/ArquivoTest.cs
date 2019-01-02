using Xunit;
using System;
using System.IO;
using ArtigoTesteMetodoVoid.Core;

namespace ArtigoTesteMetodoVoid.Tests
{
    public class ArquivoTest
    {
        [Fact]
        public void Testa_Criacao_Arquivo()
        {
            var arquivo = new Arquivo();
            var nomeArquivo = "NomeArquivo";
            arquivo.CriarArquivo(nomeArquivo);

            Assert.True(File.Exists($@"C:\{nomeArquivo}.txt"));
        }

        [Fact]
        public void Testa_Envio_Email_Vazio()
        {
            var arquivo = new Arquivo();
            var ex = Assert.Throws<ArgumentException>(() => arquivo.EnviaEmail(""));

            Assert.Equal("E-mail obrigatório", ex.Message);
        }

        [Fact]
        public void Testa_Envio_Email_Invalido()
        {
            var arquivo = new Arquivo();
            var ex = Assert.Throws<ArgumentException>(() => arquivo.EnviaEmail("email.com.br"));

            Assert.Equal("E-mail inválido", ex.Message);
        }

        [Fact]
        public void Testa_Envio_Email()
        {
            var arquivo = new Arquivo();
            var ex = Assert.Throws<ArgumentException>(() => arquivo.EnviaEmail("email@dominio.com.br"));

            Assert.Null(ex);
        }
    }
}
