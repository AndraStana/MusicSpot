// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: FriendServices.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MusicMicroservice {
  public static partial class FriendsGrpcService
  {
    static readonly string __ServiceName = "FriendsGrpcService";

    static readonly grpc::Marshaller<global::MusicMicroservice.AddFriendRequest> __Marshaller_AddFriendRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.AddFriendRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.AddFriendResponse> __Marshaller_AddFriendResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.AddFriendResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.RemoveFriendRequest> __Marshaller_RemoveFriendRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.RemoveFriendRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.RemoveFriendResponse> __Marshaller_RemoveFriendResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.RemoveFriendResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetAllPossibleFriendsRequest> __Marshaller_GetAllPossibleFriendsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetAllPossibleFriendsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetAllPossibleFriendsResponse> __Marshaller_GetAllPossibleFriendsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetAllPossibleFriendsResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetFriendsRequest> __Marshaller_GetFriendsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetFriendsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetFriendsResponse> __Marshaller_GetFriendsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetFriendsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::MusicMicroservice.AddFriendRequest, global::MusicMicroservice.AddFriendResponse> __Method_AddFriend = new grpc::Method<global::MusicMicroservice.AddFriendRequest, global::MusicMicroservice.AddFriendResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddFriend",
        __Marshaller_AddFriendRequest,
        __Marshaller_AddFriendResponse);

    static readonly grpc::Method<global::MusicMicroservice.RemoveFriendRequest, global::MusicMicroservice.RemoveFriendResponse> __Method_RemoveFriend = new grpc::Method<global::MusicMicroservice.RemoveFriendRequest, global::MusicMicroservice.RemoveFriendResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveFriend",
        __Marshaller_RemoveFriendRequest,
        __Marshaller_RemoveFriendResponse);

    static readonly grpc::Method<global::MusicMicroservice.GetAllPossibleFriendsRequest, global::MusicMicroservice.GetAllPossibleFriendsResponse> __Method_GetAllPossibleFriends = new grpc::Method<global::MusicMicroservice.GetAllPossibleFriendsRequest, global::MusicMicroservice.GetAllPossibleFriendsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllPossibleFriends",
        __Marshaller_GetAllPossibleFriendsRequest,
        __Marshaller_GetAllPossibleFriendsResponse);

    static readonly grpc::Method<global::MusicMicroservice.GetFriendsRequest, global::MusicMicroservice.GetFriendsResponse> __Method_GetFriends = new grpc::Method<global::MusicMicroservice.GetFriendsRequest, global::MusicMicroservice.GetFriendsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetFriends",
        __Marshaller_GetFriendsRequest,
        __Marshaller_GetFriendsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MusicMicroservice.FriendServicesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of FriendsGrpcService</summary>
    [grpc::BindServiceMethod(typeof(FriendsGrpcService), "BindService")]
    public abstract partial class FriendsGrpcServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.AddFriendResponse> AddFriend(global::MusicMicroservice.AddFriendRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.RemoveFriendResponse> RemoveFriend(global::MusicMicroservice.RemoveFriendRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.GetAllPossibleFriendsResponse> GetAllPossibleFriends(global::MusicMicroservice.GetAllPossibleFriendsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.GetFriendsResponse> GetFriends(global::MusicMicroservice.GetFriendsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(FriendsGrpcServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddFriend, serviceImpl.AddFriend)
          .AddMethod(__Method_RemoveFriend, serviceImpl.RemoveFriend)
          .AddMethod(__Method_GetAllPossibleFriends, serviceImpl.GetAllPossibleFriends)
          .AddMethod(__Method_GetFriends, serviceImpl.GetFriends).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, FriendsGrpcServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddFriend, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.AddFriendRequest, global::MusicMicroservice.AddFriendResponse>(serviceImpl.AddFriend));
      serviceBinder.AddMethod(__Method_RemoveFriend, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.RemoveFriendRequest, global::MusicMicroservice.RemoveFriendResponse>(serviceImpl.RemoveFriend));
      serviceBinder.AddMethod(__Method_GetAllPossibleFriends, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.GetAllPossibleFriendsRequest, global::MusicMicroservice.GetAllPossibleFriendsResponse>(serviceImpl.GetAllPossibleFriends));
      serviceBinder.AddMethod(__Method_GetFriends, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.GetFriendsRequest, global::MusicMicroservice.GetFriendsResponse>(serviceImpl.GetFriends));
    }

  }
}
#endregion
