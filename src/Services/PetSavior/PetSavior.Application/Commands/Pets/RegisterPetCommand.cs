﻿using AdoteUmPet.Core.CQRS.Commands;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Commands.Pets
{
    public class RegisterPetCommand : Command<Unit>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CareTip { get; private set; }
        public decimal Weight { get; private set; }
        public int BreedId { get; private set; }
        public bool Pedigree { get; private set; }
        public int Sex { get; private set; }

        public RegisterPetCommand(string name, string description, string careTip, decimal weight, int breedId, int sex, bool pedigree)
        {
            Name = name;
            Description = description;
            CareTip = careTip;
            Weight = weight;
            BreedId = breedId;
            Pedigree = pedigree;
            Sex = sex;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterPetCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        private class RegisterPetCommandValidator : AbstractValidator<RegisterPetCommand>
        {
            public RegisterPetCommandValidator()
            {
                RuleFor(p => p.Name)
                    .NotEmpty();

                RuleFor(p => p.Weight)
                    .NotNull();

                RuleFor(p => p.BreedId)
                    .NotNull();
            }
        }
    }
}
