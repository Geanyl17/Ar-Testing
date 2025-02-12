AR Chicken Tracking 

Original Youtube Link : https://www.youtube.com/watch?v=W9h0RU56Xa4

SETUP (not mentioned in video)

	Needed Packages
    *Universal RP (Universal RenderPipeline)
    
	 If You don't have a Render Pipeline Assets Settings Folder when you install a package
          1. Manually Create a URP Pipeline Asset
              In the Project window, go to the Assets folder.
              Right-click → Create > Rendering > Universal Render Pipeline > Pipeline Asset (Forward Renderer).
              Name it URP_RenderPipelineAsset.
          2. Assign the URP Pipeline Asset
              Go to Edit > Project Settings > Graphics.
              Look for Scriptable Render Pipeline Settings at the top.
              Click the dropdown and select URP_RenderPipelineAsset.
              If the dropdown is empty, Unity isn’t detecting the asset. Try closing and reopening Unity, then repeat
    Make a MobileRender Pipeline add it to your PipeLine List.

Android
  1. Make sure you have the android module installed in your current Unity Version.
  2. When Plugging in your android device make sure to enable debugging mode. 
