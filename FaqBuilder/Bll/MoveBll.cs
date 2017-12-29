using System;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;
using System.Linq;

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
                GetViewModelLists(viewModel);
            }
            catch (Exception e)
            {
                viewModel.Success = false;
                viewModel.Error = e.Message;
            }

            return viewModel;
        }

        public MoveViewModel GetCreateNewMoveVmForCharacterByType(int characterId, int typeId)
        {
            var viewModel = new MoveViewModel { CharacterId = characterId, MoveTypeId = typeId };

            try
            {
                GetViewModelLists(viewModel);
            }
            catch (Exception e)
            {
                viewModel.Success = false;
                viewModel.Error = e.Message;
            }

            return viewModel;
        }

        public MoveViewModel GetViewModelLists(MoveViewModel viewModel)
        {
            var character = _unitOfWork.Characters.Get(viewModel.CharacterId);

            if (character.Game.MoveTypes.Count == 0)
            {
                throw new Exception("No movetypes defined for this game.");
            }

            var moveTypes = character.Game.MoveTypes;

            viewModel.MoveTypes = moveTypes;

            return viewModel;
        }

        public MoveViewModel CreateMoveForCharacter(MoveViewModel viewModel)
        {
            try
            {
                var character = _unitOfWork.Characters.Get(viewModel.CharacterId);
                var moveWithSameName = character.Moves.FirstOrDefault(t => string.Equals(t.Name, viewModel.Name, StringComparison.CurrentCultureIgnoreCase));
                if (moveWithSameName != null)
                {
                    throw new Exception($"Error: {character.Name} already has a move named {viewModel.Name}.");
                }

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

                character.Moves.Add(newMove);

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                viewModel.Success = false;
                viewModel.Error = e.Message;
            }

            return viewModel;
        }

        public bool DeleteMove(int moveId)
        {
            try
            {
                var move = _unitOfWork.Moves.Get(moveId);
                _unitOfWork.Moves.Remove(move);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}