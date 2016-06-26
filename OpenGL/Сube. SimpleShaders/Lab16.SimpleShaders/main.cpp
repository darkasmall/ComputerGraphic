#include <GL\glew.h>
#include <GL\freeglut.h>
#include <iostream>
#include <string>
#include <fstream>
#include "GlShader.h"
#include "glm/gtc/matrix_transform.hpp"
#include "Cube.h"
#include <cmath>

using namespace std;

float rotate_angle = 3.0f;

GlShader shader;
mat4 projectionM;

GLint Attrib_coord;
GLint Attrib_color;
GLint Unif_matrix;

GLint Unif_color;
GLint Unif_mode;

vec3 color(0.3, 0.2, 0.3);
GLuint cubeVBO[3];

string vertextShaderFname = "vertexShader.txt";
string fragmentShaderFname = "fragmentShader.txt";

int mode = 1;

vec3 gradient[] = {
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),

	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),

	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),

	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),

	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),

	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f),
	vec3(1.0f, 0.0f, 1.0f),
	vec3(1.0f, 1.0f, 1.0f)
};

struct vertex {
	GLfloat x, y, z;
};

void checkOpenGLerror()
{
	GLenum errCode;
	if ((errCode = glGetError()) != GL_NO_ERROR)
		std::cout << "OpenGl error! - " << gluErrorString(errCode);
}

void initGL() {
	glClearColor(0.3, 0.3, 0.3, 0);
	glEnable(GL_DEPTH_TEST);
	glEnable(GL_TEXTURE_2D);
}

void initVBO() {
	glGenBuffers(3, cubeVBO);

	glBindBuffer(GL_ARRAY_BUFFER, cubeVBO[0]);
	glBufferData(GL_ARRAY_BUFFER, cubeVerticesCount * (3 * sizeof(float)),
		cubePositions, GL_STATIC_DRAW);
	glVertexAttribPointer(Attrib_coord, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), 0);

	glBindBuffer(GL_ARRAY_BUFFER, cubeVBO[1]);
	glBufferData(GL_ARRAY_BUFFER, sizeof(gradient), gradient, GL_STATIC_DRAW);
	glVertexAttribPointer(Attrib_color, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), 0);

	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, cubeVBO[2]);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, cubeIndicesCount * sizeof(uint32_t),
		cubeIndices, GL_STATIC_DRAW);

	checkOpenGLerror();
}

void initShader()
{
	if (!shader.loadFiles(vertextShaderFname, fragmentShaderFname))
	{
		std::cout << "error load shader \n";
		return;
	}

	// выт€гиваем ID 
	Attrib_coord = shader.getAttribLocation("coord");
	Attrib_color = shader.getAttribLocation("color");
	Unif_matrix = shader.getUniformLocation("matrix");
	Unif_color = shader.getUniformLocation("cur_color");
	Unif_mode = shader.getUniformLocation("mode");

	checkOpenGLerror();
}

void freeVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &cubeVBO[0]);
	glDeleteBuffers(1, &cubeVBO[1]);
	glDeleteBuffers(1, &cubeVBO[2]);
}

void resizeWindow(int width, int height)
{
	glViewport(0, 0, width, height);

	projectionM = glm::perspective(45.0f, (GLfloat)width / (GLfloat)height, 1.0f, 200.0f);
	projectionM = glm::translate(projectionM, vec3(0.0f, 0.0f, -100.0f));
}

// отрисовка
void render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	float n = 0;
	color.r = modf(color.r + 0.12, &n);
	color.g = modf(color.g + 0.08, &n);
	color.b = modf(color.b + 0.18, &n);

	shader.use();
	shader.setUniform(Unif_matrix, projectionM);
	shader.setUniform(Unif_color, color);
	shader.setUniform(Unif_mode, mode);

	glEnableVertexAttribArray(Attrib_coord);
	glEnableVertexAttribArray(Attrib_color);

	glDrawElements(GL_TRIANGLES, cubeIndicesCount, GL_UNSIGNED_INT, NULL);

	glDisableVertexAttribArray(Attrib_coord);
	glDisableVertexAttribArray(Attrib_color);

	checkOpenGLerror();
	glutSwapBuffers();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
		case '1':
			mode = 1;
			break;
		case '2':
			mode = 2;
			break;

		case 'w':
			projectionM = glm::translate(projectionM, vec3(0, 5, 0));
			break;
		case 's':
			projectionM = glm::translate(projectionM, vec3(0, -5, 0));
			break;
		case 'a':
			projectionM = glm::translate(projectionM, vec3(-5, 0, 0));
			break;
		case 'd':
			projectionM = glm::translate(projectionM, vec3(5, 0, 0));
			break;

		case 't':
			projectionM = glm::scale(projectionM, vec3(1, 1.1, 1));
			break;
		case 'g':
			projectionM = glm::scale(projectionM, vec3(1, 0.9, 1));
			break;
		case 'f':
			projectionM = glm::scale(projectionM, vec3(0.9, 1, 1));
			break;
		case 'h':
			projectionM = glm::scale(projectionM, vec3(1.1, 1, 1));
			break;

		case 'i':
			projectionM = glm::rotate(projectionM, rotate_angle, vec3(1, 0, 0));
			break;
		case 'k':
			projectionM = glm::rotate(projectionM, rotate_angle, vec3(-1, 0, 0));
			break;
		case 'j':
			projectionM = glm::rotate(projectionM, rotate_angle, vec3(0, -1, 0));
			break;
		case 'l':
			projectionM = glm::rotate(projectionM, rotate_angle, vec3(0, 1, 0));
			break;
		}
	glutPostRedisplay();
}

int main(int argc, char **argv)
{
	setlocale(LC_ALL, "Russian");
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_RGBA | GLUT_ALPHA | GLUT_DOUBLE);
	glutInitWindowSize(800, 600);
	glutCreateWindow("Simple shaders");
	glClearColor(0, 0, 1, 0);

	//! ќб€зательно перед инициал. шейдеров
	GLenum glew_status = glewInit();
	if (GLEW_OK != glew_status)
	{
		std::cout << "Error: " << glewGetErrorString(glew_status) << "\n";
		return 1;
	}
	if (!GLEW_VERSION_2_0)
	{
		std::cout << "No support for OpenGL 2.0 found\n";
		return 1;
	}

	initGL();
	initShader();
	initVBO();
	glutReshapeFunc(resizeWindow);
	glutDisplayFunc(render);
	glutKeyboardFunc(keyboard);

	glutMainLoop();
}