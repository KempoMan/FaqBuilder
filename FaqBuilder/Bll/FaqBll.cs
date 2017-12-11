using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FaqBuilder.Dal;
using FaqBuilder.DbContext;
using FaqBuilder.Models;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Bll
{
    public class FaqBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());

        public IEnumerable<FaqViewModel> GetAllFaqVms()
        {
            var entities = _unitOfWork.Faqs.GetAll();
            var viewModels = Mapper.Map<IEnumerable<Faq>, IEnumerable<FaqViewModel>>(entities);
            return viewModels;
        }

        public FaqViewModel CreateFaq()
        {
            var viewModel = new FaqViewModel();
            GetListsForViewModel(viewModel);

            return viewModel;
        }

        public FaqViewModel GetListsForViewModel(FaqViewModel viewModel)
        {
            viewModel.Games = _unitOfWork.Games.GetAll();

            return viewModel;
        }
    }
}