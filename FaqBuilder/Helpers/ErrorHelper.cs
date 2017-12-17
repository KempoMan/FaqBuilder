using System;

namespace FaqBuilder.Helpers
{
    public static class ErrorHelper
    {
        public static FaqBuilderViewModel SetError(FaqBuilderViewModel viewModel, Exception e)
        {
            viewModel.Success = false;
            viewModel.Error = e.Message;

            return viewModel;
        }
    }
}