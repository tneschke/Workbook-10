/* Procedural shading example for Exercise 8-2 */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;
 uniform sampler2D texture;
 varying vec3 v_normal;

const vec3 lightDir = vec3(0,0,1);

void main()
{
    vec3 nhat = normalize(v_normal);
    float lights = abs(dot(nhat, lightDir));
    gl_FragColor = vec4(lights* vec3(texture2D(texture, v_uv)),1);
}
