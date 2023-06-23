﻿using System.Diagnostics;
using Models.Constants;
﻿using Models.Interfaces.Config;
using Models.Interfaces.Services.GitCommandRunnerService;

namespace Application.GitCommandRunnerService;

public class GitCommandRunnerService : IGitCommandRunnerService
{
  // Repository & Remote details for git commands
  private IRepositoryDetails repositoryDetail;
  private string remote;

  public void SetGitRepoDetail(IRepositoryDetails repoDetail, string remote = GlobalConstants.gitDefaultRemote)
  {
    // Sets the global git command details for the repository
    this.repositoryDetail = repoDetail;
    this.remote = remote;
  }

  public bool CheckWorkingTreeForOutstandingChanges()
  {
    throw new NotImplementedException();
  }

  public void GitStashSave()
  {
    throw new NotImplementedException();
  }

  public void GitStashPop(string stashName = GlobalConstants.gitTempStashName)
  {
    throw new NotImplementedException();
  }

  public void GitFetch(string? name = null)
  {
    throw new NotImplementedException();
  }

  public void GitPull(string? name = null)
  {
    throw new NotImplementedException();
  }

  public string GitLog(string from, string to)
  {
    throw new NotImplementedException();
  }

  public string? ExecuteGitCommand(string gitCommand)
  {
    // Configures the ProcessStartInfo needed to execute the provided git command
    var processStartInfo = new ProcessStartInfo
    {
      FileName = "git",
      Arguments = gitCommand,
      WorkingDirectory = repositoryDetail.Path,
      RedirectStandardOutput = true,
      RedirectStandardError = true,
      UseShellExecute = false,
      CreateNoWindow = true
    };

    // Execute the git command using the ProcessStartInfo
    using var gitProcess = Process.Start(processStartInfo);
    if (gitProcess == null) return null;
    gitProcess.WaitForExit();

    // Check if there was a StandardError result
    string error = gitProcess.StandardError.ReadToEnd();
    // TODO: currently not dealing with the error.

    // Check if there was a StandardOutput result or StandardError result
    string output = gitProcess.StandardOutput.ReadToEnd();
    return output;
  }
}