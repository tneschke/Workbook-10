/* Procedural shading example for Exercise 8-3 */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;
uniform sampler2D colormap;


void main()
{
    vec4 lookupColor = texture2D(colormap,v_uv);
    gl_FragColor = lookupColor;
    }
