#include <GL\glew.h>
#include <GL\freeglut.h>
#include <string>
#include <fstream>
#include <iostream>
#include <vector>

#include "Rotate.h"

using namespace std;

const int WIDTH = 800;
const int HEIGHT = 600;
const int ROTATE_ANGLE = 5;
const double PI = 3.14159;

vector <vector<Point>> verges;

struct Light {
	bool isActive = false;
	float *position, *ambient, *diffuse, *specular;
	~Light() {
		delete position;
		delete ambient;
		delete diffuse;
		delete specular;
	}
};

struct Material {
	float *ambient, *diffuse, *specular, *emission, shininess;
	~Material() {
		delete ambient;
		delete diffuse;
		delete specular;
		delete emission;
	}
};

const int lights_count = 1;
Light lights[lights_count];
Material material;

void readFigure(int sz)
{
		vector<Point> vertexes = {
			Point(0, sz * 1, 0),
			Point(sz * 0.951, sz * 0.5, sz  * -0.309),
			Point(sz * 0.587, sz * 0.5, sz * 0.809),
			Point(sz * -0.587, sz * 0.5, sz * 0.809),
			Point(sz * -0.951, sz * 0.5, sz * -0.309),
			Point(0, sz * 0.5, sz * -1),
			Point(sz * 0.951, sz * -0.5, sz * 0.309),
			Point(0, sz * -0.5, 1),
			Point(sz * -0.951, sz * -0.5, sz * 0.309),
			Point(sz * -0.587, sz * -0.5, sz * -0.809),
			Point(sz * 0.587, sz * -0.5, sz * -0.809),
			Point(0, sz * -1, 0) };


		verges.push_back({vertexes[0], vertexes[2], vertexes[1]});
		verges.push_back({ vertexes[0], vertexes[3], vertexes[2] });
		verges.push_back({ vertexes[0], vertexes[4], vertexes[3] });
		verges.push_back({ vertexes[0], vertexes[5], vertexes[4] });
		verges.push_back({ vertexes[0], vertexes[1], vertexes[5] });

		verges.push_back({ vertexes[1], vertexes[2], vertexes[6] });
		verges.push_back({ vertexes[2], vertexes[7], vertexes[6] });
		verges.push_back({ vertexes[2], vertexes[3], vertexes[7] });
		verges.push_back({ vertexes[3], vertexes[8], vertexes[7] });
		verges.push_back({ vertexes[3], vertexes[4], vertexes[8] });

		verges.push_back({ vertexes[4], vertexes[9], vertexes[8] });
		verges.push_back({ vertexes[4], vertexes[5], vertexes[9] });
		verges.push_back({ vertexes[5], vertexes[10], vertexes[9] });
		verges.push_back({ vertexes[5], vertexes[1], vertexes[10] });
		verges.push_back({ vertexes[1], vertexes[6], vertexes[10] });

		verges.push_back({ vertexes[7], vertexes[11], vertexes[6] });
		verges.push_back({ vertexes[7], vertexes[8], vertexes[11] });
		verges.push_back({ vertexes[9], vertexes[11], vertexes[8] });
		verges.push_back({ vertexes[9], vertexes[10], vertexes[11] });
		verges.push_back({ vertexes[10], vertexes[6], vertexes[11] });
}


void specialKeys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP:
		rotate(ROTATE_ANGLE, 1, 0, 0, verges);
		break;
	case GLUT_KEY_DOWN:
		rotate(-ROTATE_ANGLE, 1, 0, 0, verges);
		break;
	case GLUT_KEY_LEFT:
		rotate(ROTATE_ANGLE, 0, 1, 0, verges);
		break;
	case GLUT_KEY_RIGHT:
		rotate(-ROTATE_ANGLE, 0, 1, 0, verges);
		break;
	case GLUT_KEY_PAGE_UP:
		rotate(ROTATE_ANGLE, 0, 0, 1, verges);
		break;
	case GLUT_KEY_PAGE_DOWN:
		rotate(-ROTATE_ANGLE, 0, 0, 1, verges);
		break;
	}
	glutPostRedisplay();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
	case 'w':
		lights[0].position[1] += 5;
		break;
	case 's':
		lights[0].position[1] -= 5;
		break;
	case 'a':
		lights[0].position[0] -= 5;
		break;
	case 'd':
		lights[0].position[0] += 5;
		break;
	}
}

void changeSize(int w, int h)
{
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60, (GLdouble)w / (GLdouble)h, 1, 1000);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glTranslated(0, 0, -500);
}


void init()
{
	glClearColor(0xA9 / 256.0, 0xA9 / 256.0, 0xA9 / 256.0, 1);
	glColor3f(0, 0, 0xFF / 256.0);
	glEnable(GL_DEPTH_TEST);
	glEnable(GL_LIGHTING);
	readFigure(100);

	lights[0].isActive = true;
	lights[0].position = new float[4]{ 0.0f, -100.0f, 200.0f, 1.0f };
	lights[0].ambient = new float[4]{ 0.0f, 0.0f, 0.0f, 1.0f };
	lights[0].diffuse = new float[4]{ 191.0f / 256, 249.0f / 256, 253.0 / 256, 1.0f };
	lights[0].specular = new float[4]{ 0.8f, 1.0f, 1.0f, 1.0f };

	material.ambient = new float[4]{ 190.0 / 256, 190.0 / 256, 190.0 / 256, 1.0 };
	material.diffuse = new float[4]{ 190.0 / 256, 190.0 / 256, 190.0 / 256, 1.0 };
	material.specular = new float[4]{ 190.0 / 256, 190.0 / 256, 190.0 / 256, 1.0 };
	material.emission = new float[4]{ 0.0f, 0.0f, 0.0f, 0.0f };
	material.shininess = 0.5f * 128;
}

void recalcLight() {
	for (int i = 0; i < lights_count; i++) {
		if (lights[i].isActive) {
			unsigned light_ind = GL_LIGHT0 + i;
			glEnable(light_ind);
			glLightfv(light_ind, GL_POSITION, lights[i].position);
			glLightfv(light_ind, GL_AMBIENT, lights[i].ambient);
			glLightfv(light_ind, GL_DIFFUSE, lights[i].diffuse);
			glLightfv(light_ind, GL_SPECULAR, lights[i].specular);
		}
	}

	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, material.ambient);
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, material.diffuse);
	glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, material.specular);
	glMaterialfv(GL_FRONT_AND_BACK, GL_EMISSION, material.emission);
	glMaterialf(GL_FRONT_AND_BACK, GL_SHININESS, material.shininess);
}

void Render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glPushMatrix();
	for (unsigned i = 0; i < verges.size(); i++) {
		glBegin(GL_TRIANGLES);
		for (unsigned j = 0; j < verges[i].size(); j++)
			glVertex3f(verges[i][j].x, verges[i][j].y, verges[i][j].z);
		glEnd();
	}
	glPopMatrix();


	glColor3f(1, 1, 1);
	for (int i = 0; i < lights_count; i++) {
		glPushMatrix();
		if (lights[i].isActive)
			glTranslatef(lights[i].position[0], lights[i].position[1], lights[i].position[2]);
		glutSolidSphere(15, 10, 10);
		glPopMatrix();
	}

	recalcLight();
	glutSwapBuffers();

	glPopMatrix();

	glutPostRedisplay();
}

int main(int argc, char ** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGB | GLUT_DEPTH);
	glutInitWindowSize(WIDTH, HEIGHT);
	glutInitWindowPosition(150, 50);
	glutCreateWindow("Diamond");

	glutDisplayFunc(Render);
	glutReshapeFunc(changeSize);
	glutSpecialFunc(specialKeys);
	glutKeyboardFunc(keyboard);

	init();

	glutMainLoop();
}