# Epiphany Extensions

A collection of utility methods that are common and useful in all Epiphany Umbraco builds.

## The Epiphany Git Submodule Crash-Course 101 for Dummies

### Instructions

    git submodule add -b master https://github.com/epiphanysearch/epiphany-extensions.git epiphany-extensions
    <Use VS to add the project within the folder to your solution>
    <Add a reference to the project to your main project>
    <Add and commit everything to your project>

You now have the latest of the epiphany-extensions project within your project. 

It is encouraged by **ME** for **YOU** to add useful stuff that you will probably use again and again. You can do this by editing the files in VS as you would normally.

This is like another repository, so you have to commit changes to that repository as a seperate step (GitEx recognises this and will show changes in the commit window - right-click for the option to commit the changes). To push the changes upstream, you will have to do this manually in command-line (oh no!). That's easy though.

    <In c:\YOURPROJECTDIR\epiphany-extensions>
    git push

By design, if someone wanted the very latest changes in their project, they will have to do a manual pull, similarly to having to do a push.

    <In c:\YOURPROJECTDIR\epiphany-extensions>
    git pull

## Future Plans

- [ ] Re-write Epiphany SEO extensions after having a better understanding of Umbraco (new repository)
- [ ] Add an asset folder containing things like `SiteMap.cshtml` partial, `GoogleSiteMap.cshtml` partial, etc.
- [ ] Detector.cs
- [ ] YouTubePicker.cs / YouTubeSelector.cs
- [ ] SendEmailWithFileLink.cs (requires Contour)
