#version 330 core
layout (location = 0) out vec3 gPositionDS;
layout (location = 1) out vec3 gNormalDS;
layout (location = 2) out vec4 gAlbedoSpecDS;

in vec2 TexCoords;
in vec3 FragPos;
in vec3 Normal;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

void main()
{    
    // store the fragment position vector in the first gbuffer texture
    gPositionDS = FragPos;
    // also store the per-fragment normals into the gbuffer
    gNormalDS = normalize(Normal);
    // and the diffuse per-fragment color
    gAlbedoSpecDS.rgb = texture(texture_diffuse1, TexCoords).rgb;
    // store specular intensity in gAlbedoSpec's alpha component
    gAlbedoSpecDS.a = texture(texture_specular1, TexCoords).r;
}
