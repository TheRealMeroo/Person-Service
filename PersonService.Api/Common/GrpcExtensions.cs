using Grpc.Core;

namespace PersonService.Api.Common;

public static class GrpcExtensions
{
    public static Guid ToGuidOrThrow(this string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"Id must be a valid GUID. Provided: '{id}'"));
        return guid;
    }
}