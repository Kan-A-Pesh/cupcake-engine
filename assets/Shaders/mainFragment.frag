#version 330 core
out vec4 FragColor;

in vec4 vertexColor;
in vec3 normal;

uniform vec3 lightDir;
uniform vec3 viewPos;

void main()
{
	// We do not need to normalize since it is already normalized
	// vec3 norm = normalize(Normal);
	float ambient = 0.1;
	float diffuse = max(-dot(normal, lightDir), 0.0);
	
	FragColor = (ambient + diffuse) * vertexColor;
}