﻿using N56Home.Models;
using N56Home.Services;

var folderService = new FolderService();

folderService.Execute(Directory.GetCurrentDirectory(), "Storage");

var userBase = folderService.CreateFolder(new User(Guid.NewGuid(), "Ozodbek", "Anavrjonovv"));
Console.WriteLine(userBase);

var userResumeFolder = folderService.CreateFolder(userBase, "Resume");
Console.WriteLine(userResumeFolder);

var userProfileFolder = folderService.CreateFolder(userBase, "Profile");
Console.WriteLine(userProfileFolder);