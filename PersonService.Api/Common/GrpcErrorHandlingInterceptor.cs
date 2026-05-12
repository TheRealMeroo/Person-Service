using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.EntityFrameworkCore;
using PersonService.Domain.Exceptions;

namespace PersonService.Api.Common;

public class GrpcErrorHandlingInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (DomainValidationException ex)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
        }
        catch (KeyNotFoundException ex)
        {
            throw new RpcException(new Status(StatusCode.NotFound, ex.Message));
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new RpcException(new Status(StatusCode.Aborted,
                "Concurrency conflict – please retry"));
        }
        catch (Exception ex) when (!(ex is RpcException))
        {
            return await Task.FromException<TResponse>(
                new RpcException(new Status(StatusCode.Internal, "Internal server error")));
        }
    }
}