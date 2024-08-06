using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class FilmeController : Controller
{
    public ViewResult Listar()
    {
        var dbContext = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(dbContext);

        var filmes = repositorioFilme.SelecionarTodos();

        var listarFilmesViewModels = filmes
            .Select(f => new ListarFilmeViewModel { Id = f.Id, Titulo = f.Titulo, Duracao = f.Duracao, DataLancamento = f.DataLancamento, Genero = f.Genero});

        return View(listarFilmesViewModels);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirFilmeViewModel inserirFilmeVm)
    {
        if (!ModelState.IsValid)
            return View(inserirFilmeVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(db);

        var filme = new Filme(inserirFilmeVm.Titulo, inserirFilmeVm.Duracao, inserirFilmeVm.DataLancamento, inserirFilmeVm.Genero);

        repositorioFilme.Inserir(filme);

        HttpContext.Response.StatusCode = 201;

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{filme.Id}] foi cadastrada com sucesso!",
            LinkRedirecionamento = "/filme/listar"
        };

        return View("mensagens", notificacaoVm);
    }


    public ViewResult Editar(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(db);

        var filmeOriginal = repositorioFilme.SelecionarPorId(id);

        var editarFilmeVm = new EditarFilmeViewModel
        {
            Id = id,
            Titulo = filmeOriginal.Titulo,
            Duracao = filmeOriginal.Duracao,
            DataLancamento = filmeOriginal.DataLancamento,
            Genero = filmeOriginal.Genero
        };

        return View(editarFilmeVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarFilmeViewModel editarFilmeVm)
    {
        if (!ModelState.IsValid)
            return View(editarFilmeVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(db);

        var filmeOriginal = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

        filmeOriginal.Titulo = editarFilmeVm.Titulo;
        filmeOriginal.Duracao = editarFilmeVm.Duracao;
        filmeOriginal.DataLancamento = editarFilmeVm.DataLancamento;
        filmeOriginal.Genero = editarFilmeVm.Genero;

        repositorioFilme.Editar(filmeOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{filmeOriginal.Id}] foi editado com sucesso!",
            LinkRedirecionamento = "/filme/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(db);

        var filmeParaExcluir = repositorioFilme.SelecionarPorId(id);

        var excluirFilmeVm = new ExcluirFilmeViewModel
        {
            Id = id,
            Titulo = filmeParaExcluir.Titulo,
            Duracao = filmeParaExcluir.Duracao,
            DataLancamento = filmeParaExcluir.DataLancamento,
            Genero = filmeParaExcluir.Genero
        };

        return View(excluirFilmeVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirFilmeViewModel excluirFilmeVm)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(db);

        var filmeParaExcluir = repositorioFilme.SelecionarPorId(excluirFilmeVm.Id);

        repositorioFilme.Excluir(filmeParaExcluir);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{filmeParaExcluir.Id}] foi excluído com sucesso!",
            LinkRedirecionamento = "/filme/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var dbContext = new ControleDeCinemaDbContext();
        var repositorioFilme = new RepositorioFilmeEmOrm(dbContext);

        var filmeOriginal = repositorioFilme.SelecionarPorId(id);

        ViewBag.Filme = filmeOriginal;

        return View();
    }
}

