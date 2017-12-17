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
            return new CharacterViewModel {GameId = gameId};
        }

        public CharacterViewModel CreateCharacter(CharacterViewModel viewModel)
        {
            try
            {
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

            return viewModel;
        }
    }
}