using System;
using System.Collections.Generic;
using System.Net;
using FoodManager.Infrastructure.Exceptions.Client;

namespace FoodManager.Infrastructure.Dictionaries
{
    public static class ExceptionDictionary
    {
        public static readonly IDictionary<HttpStatusCode, Type> ExceptionTypeToStatusCode = new Dictionary
            <HttpStatusCode, Type>
        {
            {0, typeof (ServerNotFoundException)},
            {HttpStatusCode.NotFound, typeof (NotFoundException)},
            {HttpStatusCode.BadRequest, typeof (BadRequestException)},
            {HttpStatusCode.Unauthorized, typeof (UnauthorizedException)},
            {HttpStatusCode.Forbidden, typeof (ForbiddenException)},
            {HttpStatusCode.ExpectationFailed, typeof (ExpectationFailedException)},
            {HttpStatusCode.InternalServerError, typeof (InternalServerException)},
            {HttpStatusCode.MethodNotAllowed, typeof (MethodNotAllowedException)}
        };
    }
}