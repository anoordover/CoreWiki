﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CoreWiki.Application.Common;
using MediatR;

namespace CoreWiki.Application.Articles.Managing.Commands
{
	public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, CommandResult>
	{

		private readonly IArticleManagementService _articleManagementService;

		public EditArticleCommandHandler(IArticleManagementService articleManagementService)
		{
			_articleManagementService = articleManagementService;
		}

		public async Task<CommandResult> Handle(EditArticleCommand request, CancellationToken cancellationToken)
		{
			var result = new CommandResult { Successful = false };
			try
			{
				await _articleManagementService.Update(request.Id, request.Topic, request.Content, request.AuthorId, request.AuthorName);
				result.Successful = true;
				return result;
			}
			catch (Exception ex)
			{
				result.Exception = ex;
				return result;
			}
		}
	}

}
