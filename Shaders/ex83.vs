/*
 * Simple Shader for exercise 8-3
 * The student should make this more interesting, but the interesting parts
 * might be the fragment shader.
  */

/* pass interpolated variables to the fragment */
varying vec2 v_uv;
uniform float depth;
uniform sampler2D colormap;



/* the vertex shader just passes stuff to the fragment shader after doing the
 * appropriate transformations of the vertex information
 */
void main() {
    float height = texture2D(colormap,uv).r;    // get the green value

    vec3 pos = position + height*normal * depth;

    // the main output of the shader (the vertex position)
    gl_Position = projectionMatrix * modelViewMatrix * vec4( pos, 1.0 );

    v_uv = uv;
}
