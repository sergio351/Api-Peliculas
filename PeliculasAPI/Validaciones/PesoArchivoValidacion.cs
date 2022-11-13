﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class PesoArchivoValidacion: ValidationAttribute
    {
        private readonly int pesoMaximo;

        public PesoArchivoValidacion(int PesoMaximo)
        {
            pesoMaximo = PesoMaximo;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length> pesoMaximo*1024*1024)
            {
                return new ValidationResult($"el peso del archivo no puede ser mayor a: {pesoMaximo} mb");

            }
            return ValidationResult.Success;
        }
    }
}
