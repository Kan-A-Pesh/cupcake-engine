#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec3 aColor;
layout (location = 2) in vec3 aNormal;
out vec4 vertexColor;
out vec3 normal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	vertexColor = vec4(aColor.rgb, 1.0);
    normal = aNormal;
	
	gl_Position = projection * view * model * vec4(aPosition.xyz, 1.0);
}