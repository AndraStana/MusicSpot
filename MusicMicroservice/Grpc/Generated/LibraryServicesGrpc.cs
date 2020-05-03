// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: LibraryServices.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MusicMicroservice {
  public static partial class LibraryGrpcService
  {
    static readonly string __ServiceName = "LibraryGrpcService";

    static readonly grpc::Marshaller<global::MusicMicroservice.AddLibraryRequest> __Marshaller_AddLibraryRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.AddLibraryRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.AddLibraryResponse> __Marshaller_AddLibraryResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.AddLibraryResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetLibrarySongsRequest> __Marshaller_GetLibrarySongsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetLibrarySongsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetLibrarySongsResponse> __Marshaller_GetLibrarySongsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetLibrarySongsResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetPopularityRankingRequest> __Marshaller_GetPopularityRankingRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetPopularityRankingRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MusicMicroservice.GetPopularityRankingResponse> __Marshaller_GetPopularityRankingResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MusicMicroservice.GetPopularityRankingResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::MusicMicroservice.AddLibraryRequest, global::MusicMicroservice.AddLibraryResponse> __Method_AddLibrary = new grpc::Method<global::MusicMicroservice.AddLibraryRequest, global::MusicMicroservice.AddLibraryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddLibrary",
        __Marshaller_AddLibraryRequest,
        __Marshaller_AddLibraryResponse);

    static readonly grpc::Method<global::MusicMicroservice.GetLibrarySongsRequest, global::MusicMicroservice.GetLibrarySongsResponse> __Method_GetLibrarySongs = new grpc::Method<global::MusicMicroservice.GetLibrarySongsRequest, global::MusicMicroservice.GetLibrarySongsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLibrarySongs",
        __Marshaller_GetLibrarySongsRequest,
        __Marshaller_GetLibrarySongsResponse);

    static readonly grpc::Method<global::MusicMicroservice.GetPopularityRankingRequest, global::MusicMicroservice.GetPopularityRankingResponse> __Method_GetPopularityRankings = new grpc::Method<global::MusicMicroservice.GetPopularityRankingRequest, global::MusicMicroservice.GetPopularityRankingResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPopularityRankings",
        __Marshaller_GetPopularityRankingRequest,
        __Marshaller_GetPopularityRankingResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MusicMicroservice.LibraryServicesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LibraryGrpcService</summary>
    [grpc::BindServiceMethod(typeof(LibraryGrpcService), "BindService")]
    public abstract partial class LibraryGrpcServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.AddLibraryResponse> AddLibrary(global::MusicMicroservice.AddLibraryRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.GetLibrarySongsResponse> GetLibrarySongs(global::MusicMicroservice.GetLibrarySongsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MusicMicroservice.GetPopularityRankingResponse> GetPopularityRankings(global::MusicMicroservice.GetPopularityRankingRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(LibraryGrpcServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddLibrary, serviceImpl.AddLibrary)
          .AddMethod(__Method_GetLibrarySongs, serviceImpl.GetLibrarySongs)
          .AddMethod(__Method_GetPopularityRankings, serviceImpl.GetPopularityRankings).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, LibraryGrpcServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddLibrary, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.AddLibraryRequest, global::MusicMicroservice.AddLibraryResponse>(serviceImpl.AddLibrary));
      serviceBinder.AddMethod(__Method_GetLibrarySongs, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.GetLibrarySongsRequest, global::MusicMicroservice.GetLibrarySongsResponse>(serviceImpl.GetLibrarySongs));
      serviceBinder.AddMethod(__Method_GetPopularityRankings, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MusicMicroservice.GetPopularityRankingRequest, global::MusicMicroservice.GetPopularityRankingResponse>(serviceImpl.GetPopularityRankings));
    }

  }
}
#endregion
