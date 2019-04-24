/* Procedural shading example for Exercise 8-1 */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;
varying vec3 v_normal;
const vec3 lightDir = vec3(0,0,1);

void main()
{
    vec3 nhat = normalize(v_normal);
    float lights = abs(dot(nhat, lightDir));




    const vec3 light = vec3(.5,.1,.1);
    const vec3 dark = vec3(1,.1,.1);

    float xPos = v_uv.x / .2;
    float yPos = v_uv.y / .2;

    float yPosHalf = yPos * .5;
    float yPosHalfFloor = floor(yPosHalf);


    if (yPosHalf - yPosHalfFloor >= .5)
        xPos += 0.5;

        

    float xPosFloor = floor(xPos);
    xPos = xPos - xPosFloor;

    float yPosFloor = floor(yPos);
    yPos = yPos - yPosFloor;



    float dcX = step(xPos, .8);
    float dcY = step(yPos, .7);


    float dc = dcX*dcY;

    gl_FragColor = vec4(lights*(mix(light, dark, dc)) , 1.);
}
