using Niis.Eokno.Abstractions.Helpers;
using Niis.Eokno.Abstractions.Requests;
using Niis.Eokno.Abstractions.Responses;
using System;
using System.Xml.Linq;

namespace Niis.Eokno.Builders
{
	public class SendMessageResponseBuilder
	{
		private SendMessageRequest _request;
		private RequestInfo _requestInfo;
		private Status _status;
		private ResponseData _responseData;

		public SendMessageResponseBuilder AddRequest(SendMessageRequest request)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(SendMessageRequest));
			}

			_request = request;
			return this;
		}

		public SendMessageResponseBuilder WithStatus(Status status)
		{
			if (status == null)
			{
				throw new ArgumentNullException(nameof(Status));
			}

			_status = status;
			return this;
		}

		public SendMessageResponseBuilder BindResponseInfoFromRequestInfo()
		{
			if (_request?.Request == null)
			{
				throw new InvalidOperationException(nameof(Request));
			}

			if (_request.Request.RequestInfo == null)
			{
				throw new ArgumentNullException(nameof(RequestInfo));
			}

			_requestInfo = _request.Request.RequestInfo;
			return this;
		}

		public SendMessageResponseBuilder BindResponseInfoFromRequestInfo(RequestInfo requestInfo)
		{
			if (requestInfo == null)
			{
				throw new ArgumentNullException(nameof(RequestInfo));
			}

			_requestInfo = requestInfo;
			return this;
		}

		public SendMessageResponseBuilder WithSuccessStatus()
		{
			_status = StatusDescriber.Success();
			return this;
		}

		public SendMessageResponseBuilder WithFailedStatus()
		{
			_status = StatusDescriber.Failed();
			return this;
		}

		public SendMessageResponseBuilder WithData(XElement data)
		{
			_responseData = new ResponseData
			{
				Data = data
			};
			return this;
		}

		public SendMessageResponseBuilder WithEmptyData()
		{
			_responseData = new ResponseData();
			return this;
		}

		public SendMessageResponse Build()
		{
			var messageResponse = new SendMessageResponse();

			var response = new Response
			{
				ResponseInfo = new ResponseInfo
				{
					MessageId = _requestInfo.MessageId,
					ResponseDate = DateTime.Now,
					SessionId = _requestInfo.SessionId,
					Status = _status
				},
				ResponseData = _responseData.Data
			};

			messageResponse.Response = response;

			return messageResponse;
		}
	}
}
