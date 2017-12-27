using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Helpers;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class CharacterBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());

        public CharacterViewModel GetNewCharacterVm(int gameId)
        {
            var newVm = new CharacterViewModel {GameId = gameId};
            return newVm;
        }

        public CharacterViewModel CreateCharacter(CharacterViewModel viewModel)
        {
            try
            {
                CheckForDuplicate(viewModel);

                var newCharacter = new Character();
                Mapper.Map(viewModel, newCharacter);

                _unitOfWork.Characters.Add(newCharacter);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                ErrorHelper.SetError(viewModel, e);
            }

            return viewModel;
        }

        private void CheckForDuplicate(CharacterViewModel viewModel)
        {
            var existingCharacter = _unitOfWork.Characters.Find(t => t.Name == viewModel.Name).FirstOrDefault();

            if (existingCharacter != null && existingCharacter.Id != viewModel.Id)
            {
                throw new Exception($"A character named \"{viewModel.Name}\" already exists.");
            }
        }

        public CharacterViewModel GetCharacterVm(int characterId)
        {
            var viewModel = new CharacterViewModel {Id = characterId};
            try
            {
                var entity = _unitOfWork.Characters.Get(characterId);
                Mapper.Map(entity, viewModel);
            }
            catch (Exception e)
            {
                ErrorHelper.SetError(viewModel, e);
            }

            foreach (var move in viewModel.Moves)
            {
                move.Motion = RemoveWhitespace(move.Motion);
            }

            return viewModel;
        }

        public CharacterViewModel UpdateCharacter(CharacterViewModel viewModel)
        {
            try
            {
                CheckForDuplicate(viewModel);

                var entity = _unitOfWork.Characters.Get(viewModel.Id);
                Mapper.Map(viewModel, entity);

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                ErrorHelper.SetError(viewModel, e);
            }

            return viewModel;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}