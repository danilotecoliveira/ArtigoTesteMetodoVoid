using System;
using ArtigoTesteMetodoVoid.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtigoTesteMetodoVoid.Tests
{
    [TestClass]
    public class UsuarioTestes
    {
        private static Usuario _usuario;
        public UsuarioTestes() => _usuario = new Usuario();

        [TestInitialize]
        public void Configuracao()
        {
            _usuario.Id = Guid.NewGuid();
            _usuario.Nome = "Nome do Usuario Teste";
        }

        [TestMethod]
        public void Inserir_Usuario_Com_Sucesso()
        {
            var resultado = _usuario.InserirUsuario(_usuario);

            Assert.IsNotNull(resultado.Id);
            Assert.AreNotEqual(Guid.Empty, resultado.Id);
        }

        [TestMethod]
        public void Teste_Para_Inativar_Usuario()
        {
            //
        }

        [TestCleanup]
        public void LimparTestes()
        {
            _usuario.DeletarUsuario(_usuario.Id);
        }
    }
}
