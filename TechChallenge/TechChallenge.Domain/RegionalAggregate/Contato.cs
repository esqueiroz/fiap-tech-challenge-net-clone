﻿using System.Text.RegularExpressions;

namespace TechChallenge.Domain.RegionalAggregate
{
    public class Contato : EntityBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid RegionalId { get; set; }

        public Regional Regional { get; set; }

        protected Contato(string nome, string telefone, string email, Guid regionalId)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            RegionalId = regionalId;
        }

        public Contato Criar(string nome, string telefone, string email, Guid regionalId)
        {
            if (String.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da Regional inválido");


            if (String.IsNullOrWhiteSpace(telefone) || !ValidarTelefone(telefone))
                throw new ArgumentException("Telefone inválido");

            if (String.IsNullOrWhiteSpace(email) || !ValidarEmail(email) || Email.Length > 150)
                throw new ArgumentException("E-mail inválido");


            return new Contato(nome, telefone, email, regionalId);
        }

        private bool ValidarEmail(string email)
        {
            return Regex.IsMatch(email, "/^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$/i");
        }

        private bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, "^\\([1-9]{2}\\) (?:[2-8]|9[0-9])[0-9]{3}\\-[0-9]{4}$");
        }
    }
}
