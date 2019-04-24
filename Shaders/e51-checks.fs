/* a simple procedural texture for exercise 5-1 */
/* the student should change this to implement a checkerboard */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

/* colors for the checkerboard */
uniform vec3 light;
uniform vec3 dark;

/* number of checks over the UV range */
uniform float checks;

void main()
{
    float dc = 0.0;

    float fraction = 1.0 / checks;

    float countX = floor(v_uv.x / fraction);
    float countY = floor(v_uv.y / fraction);

    float sum = (countX + countY) / 2.0;
    float sumFloor = floor(sum);

    if(sum - sumFloor == 0.0 ){
        dc = 1.0;
    } 


    gl_FragColor = vec4(mix(light,dark,dc), 1.);
}
