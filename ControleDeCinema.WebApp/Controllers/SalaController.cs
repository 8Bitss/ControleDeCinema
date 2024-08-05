using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.ModuloSala;
using ControleDeCinema.Infra.Orm.ModuloSala;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class SalaController : Controller
{
    public ViewResult Listar()
    {
        var dbContext = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(dbContext);

        var salas = repositorioSala.SelecionarTodos();

        var listarSalasViewModels = salas
            .Select(s => new ListarSalaViewModel { Id = s.Id, Capacidade = s.Capacidade});

        return View(listarSalasViewModels);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirSalaViewModel inserirSalaVm)
    {
        if (!ModelState.IsValid)
            return View(inserirSalaVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = new Sala(inserirSalaVm.Capacidade);

        List<Poltrona> poltronas = new List<Poltrona>();

        for (int i = 1; i <= sala.Capacidade; i++)
        {
            poltronas.Add(new Poltrona());
        }

        repositorioSala.Inserir(sala);

        HttpContext.Response.StatusCode = 201;

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{sala.Id}] foi cadastrada com sucesso!",
            LinkRedirecionamento = "/sala/listar"
        };

        return View("mensagens", notificacaoVm);
    }


    public ViewResult Editar(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salaOriginal = repositorioSala.SelecionarPorId(id);

        var editarSalaVm = new EditarSalaViewModel
        {
            Id = id,
            Capacidade = salaOriginal.Capacidade
        };

        return View(editarSalaVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarSalaViewModel editarSalaVm)
    {
        if (!ModelState.IsValid)
            return View(editarSalaVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);

        salaOriginal.Capacidade = editarSalaVm.Capacidade;
        
        repositorioSala.Editar(salaOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{salaOriginal.Id}] foi editado com sucesso!",
            LinkRedirecionamento = "/sala/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salaParaExcluir = repositorioSala.SelecionarPorId(id);

        var excluirSalaVm = new ExcluirSalaViewModel
        {
            Id = id,
            Capacidade = salaParaExcluir.Capacidade,
            QtdAssentosDisponiveis = salaParaExcluir.QtdAssentosDisponiveis,
            Poltronas = salaParaExcluir.Poltronas
        };

        return View(excluirSalaVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salaParaExcluir = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

        repositorioSala.Excluir(salaParaExcluir);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{salaParaExcluir.Id}] foi excluído com sucesso!",
            LinkRedirecionamento = "/sala/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var dbContext = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(dbContext);

        var salaOriginal = repositorioSala.SelecionarPorId(id);

        ViewBag.Sala = salaOriginal;

        return View();
    }
}
