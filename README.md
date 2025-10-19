# Pull requests
Commits cannot be pushed to the main and release branches directly.
To add new features, make a new branch, and create a pull request to the main branch.
Once all of the required features for the next release are in main, a pull request can be made from main to the release branch.

# Naming conventions
Branches and commits are named according to the [Conventional Commit](https://www.conventionalcommits.org/en/v1.0.0/#summary) and [Conventional Branch](https://conventional-branch.github.io/#summary) standards.
Scope is optional, but preferred. All commits and branches should be in lowercase as often as possible.

# Deployment
When commits are pushed to the release branch, deployment is done automatically to the Azure server.
