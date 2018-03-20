using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIANA_Biblia
{
    public class GrammaRules
    {

        public static IList<string> WhatTimeIs = new List<string>()
        {
            "Que horas são?",
            "Me diga as horas!",
            "Poderia me diser que horas são?",
            "São que Horas?",
            "Que hora é essa?"
        };
        public static IList<string> WhatDateIs = new List<string>()
        {
            "Qual a data de hoje?",
            "Me diga a data de hoje!",
            "Que data é hoje?"
        };

        public static IList<string> DianaStartListening = new List<string>()
        {
            "Diana.",
            "Diana, você está ai?",
            "Diana, você está me escutando?",
            "Volte a me escultar!",
            "Olá Diana.",
            "Oi Diana."
        };

        public static IList<string> DianaStopListening = new List<string>()
        {
            "Pare de Ouvir!",
            "Pare de me escutar!",
            "Pare de me ouvir!"
        };

        public static IList<string> MinimizeWindowns = new List<string>() {

            "Minimizar Janela!",
            "Saia da Frente!",
            "Me deixe trabalhar!",
            "Não consigo ver nada.",
            "Você está em minha frente!"

        };


        public static IList<string> NormalizeWindowns = new List<string>()
        {
            "Apareça!",
            "Apareça Diana!",
            "Volte aqui Diana!",
            "Volte aqui!",
            "Onde você está?",
            "Não estou te Vendo."
        };

        public static IList<string> ChangeVoice = new List<string>()
        {
            "Alterar Voz",
            "Mudar Voz",
            "Alterar Padrão de voz",
            "Trocar Narrador",
            "Alterar Narrador"

        };

        public static IList<string> AtualiziComando = new List<string>()
        {
            "Atualizar Comandos"
        };

        public static IList<string> MostrarMenu = new List<string>()
        {
            "Mostrar Menu",
            "Configurar",
            "Adicionar Comandos"
        };
        public static IList<string> lerVerciculo = new List<string>()
        {
            "Ler Genesis"
        };
        public static IList<string> Capitulo = new List<string>()
        {
        };

        public static IList<string> Verciculo = new List<string>()
        {
        };

        /*
        public static IList<string> TrocarJanela = new List<string>() {

            "Mudar janela",
            "Mostrar outra janela",
            "Trocar Janela",
            "Alterar Janela"
        };
        

        public static IList<string> FeicharAplicacao = new List<string>() {

            "Sir",
            "Feichar",
            "Feichar Janela",
            "Feichar aplicativo",
            "Feichar Programa"
        };
        */

        public static IList<string> PossoDesligar = new List<string>()
        {
            "Dispensada",
            "Pode Descansar",
            "Não vou precisar mais de você"
        };

        public static IList<string> EnterComand = new List<string>()
        {
            "Confirmar",
            "Ok",
            "Sim",
            "Confirmar Desligamento",
            "Quero",
        };

        public static IList<string> Agendar = new List<string>()
        {
            "Adicionar Alarme",
            "Me lebre de",
            "Pode me lebrar de"
        };
        public static IList<string> MostrarAgenda = new List<string>()
        {
            "Mostrar Agenda",
            "Mostre meus compromissos",
            "Mostre minha agenda"
        };
        public static IList<string> Mostrarcomandos = new List<string>()
        {
            "Mostrar Comandos",
            "Mostre meus comandos",
            "Mostre os comandos do sistema"
        };


        public static IList<string> SocalComands = new List<string>()
        {
        };

        public static IList<string> SocalRespostas = new List<string>()
        {
        };
        public static IList<string> MemoriaComandos = new List<string>()
        {

        };
        public static IList<string> MemoriaRespostas = new List<string>()
        {

        };

        public static IList<string> MemoriaComandosPrograma = new List<string>()
        {
        };
        public static IList<string> MemoriaRespostasPrograma = new List<string>()
        {

        };
        public static IList<string> MemoriaDiretorioPrograma = new List<string>()
        {

        };
        public static IList<string> MemoriaComandosWeb = new List<string>()
        {
        };
        public static IList<string> MemoriaRespostasWeb = new List<string>()
        {

        };
        public static IList<string> MemoriaUrl = new List<string>()
        {

        };
    }
}
