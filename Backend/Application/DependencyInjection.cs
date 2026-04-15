// Add to your service collection
builder.Services.AddScoped<IAdoptionRequestRepository, AdoptionRequestRepository>();
builder.Services.AddScoped<IUserAdoptionVMRepo, UserAdoptionVMRepo>();
builder.Services.AddScoped<AdoptionRequestService>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<FavouriteService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<PostService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<IFileService, LocalFileService>();