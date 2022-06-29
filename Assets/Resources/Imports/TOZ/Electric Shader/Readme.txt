RELEASE NOTES:
*-----------------------------------------------*
v1.0
Initial release.
v1.1
Folder structure changed, added a sample Diffuse shader.
You can create your own shaders with electric as an additional effect now.
Check the sample shader for details.
v1.2
* Shader name changed.
* Folder structure changed.
* Shader variable names changed.
* Shader improvements.
* Fog support added.
* Single pass stereo rendering support added.
* GPU Instancing support added.

HOW TO USE:
*-----------------------------------------------*
Look at demo scene and appropriate material.
Add the material to any object and play with material properties.

HOW TO ADD THE EFFECT TO ANY OTHER SHADER:
*-----------------------------------------------*
Check the DiffuseDemoScene and Sample-Diffuse-Electric.shader file.
You will see a regular very simple surface diffuse shader with additional usepass directive,
and the electric shader properties.
If you do the same for any other shader, you will add the effect as a second pass on that one.
Beware that GPU instancing only works on first pass of any shader according to unity documents.

KNOWN ISSUES:
*-----------------------------------------------*
None

SUPPORT:
*-----------------------------------------------*
For any questions, you can contact me from aubergine2010@gmail.com.

Thanks for buying the package.