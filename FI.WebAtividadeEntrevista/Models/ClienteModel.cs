using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        public long Id { get; set; }
        
        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        [CustomValidationCPF(ErrorMessage = "Digite um CPF válido")]
        public string CPF { get; set; }

        public List<BeneficiariosModel> ListaBeneficiarios { get; set; }


    }
    public class CustomValidationCPFAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cpf = value.ToString();
                if (IsCPFValido(cpf))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }

        private bool IsCPFValido(string cpf)
        {
            // Remove qualquer formatação que possa estar presente no CPF
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 dígitos numéricos
            if (cpf.Length != 11 )
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores correspondem
            return cpf[9] == digitoVerificador1.ToString()[0] && cpf[10] == digitoVerificador2.ToString()[0];
        }
    }
}