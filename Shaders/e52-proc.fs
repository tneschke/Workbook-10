/* Procedural shading example for Exercise 5-2 */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

void main()
{
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

    gl_FragColor = vec4(mix(light, dark, dc) , 1.);
}
