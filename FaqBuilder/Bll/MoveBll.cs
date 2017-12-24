using System;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class MoveBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());


        public MoveViewModel GetCreateNewMoveVmForCharacter(int characterId)
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

        public MoveViewModel CreateMoveForCharacter(MoveViewModel viewModel)
        {
            try
            {
                var character = _unitOfWork.Characters.Get(viewModel.CharacterId);
                var movetype = _unitOfWork.MoveTypes.Get(viewModel.MoveTypeId);

                var newMove = new Move
                {
                    CharacterId = viewModel.CharacterId,
                    Character = character,
                    MoveTypeId = viewModel.MoveTypeId,
                    MoveType = movetype,
                    Name = viewModel.Name,
                    Motion = viewModel.Motion
                };

                //_unitOfWork.Moves.Add(newMove);

                //character.Moves.Add(newMove);

                _unitOfWork.Complete();
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