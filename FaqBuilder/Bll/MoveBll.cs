using System;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class MoveBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());


        public MoveViewModel CreateNewMoveForCharacter(int characterId)
        {
            var viewModel = new MoveViewModel {CharacterId = characterId};

            try
            {
                var character = _unitOfWork.Characters.Get(characterId);

                if (character.Game.MoveTypes.Count == 0)
                {
                    throw new Exception("No movetypes defined for this game.");
                }

                var moveTypes = character.Game.MoveTypes;

                viewModel.MoveTypes = moveTypes;
            }
            catch (Exception e)
            {
                viewModel.Success = false;
                viewModel.Error = e.Message;
            }

            return viewModel;
        }
    }
}