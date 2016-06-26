#ifndef CUBE_H
#define CUBE_H

#include "GlShader.h"

const uint32_t cubeIndicesCount = 36;
static const uint32_t cubeVerticesCount = 24;
const float s = 15.0f;

const float cubePositions[cubeVerticesCount][3] = {
	{ -s, s, s },{ s, s, s },{ s,-s, s },{ -s,-s, s }, // front
	{ s, s,-s },{ -s, s,-s },{ -s,-s,-s },{ s,-s,-s }, // back
	{ -s, s,-s },{ s, s,-s },{ s, s, s },{ -s, s, s }, // top
	{ s,-s,-s },{ -s,-s,-s },{ -s,-s, s },{ s,-s, s }, // bottom
	{ -s, s,-s },{ -s, s, s },{ -s,-s, s },{ -s,-s,-s }, // left
	{ s, s, s },{ s, s,-s },{ s,-s,-s },{ s,-s, s }  // right
};

// индексы вершин куба в порядке поротив часовой стрелки
const uint32_t cubeIndices[cubeIndicesCount] = {
	0, 3, 1,  1, 3, 2, // front
	4, 7, 5,  5, 7, 6, // back
	8,11, 9,  9,11,10, // top
	12,15,13, 13,15,14, // bottom
	16,19,17, 17,19,18, // left
	20,23,21, 21,23,22  // right
};

// текстурные координаты куба
const float cubeTexcoords[cubeVerticesCount][2] = {
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }, // front
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }, // back
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }, // top
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }, // bottom
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }, // left
	{ 0.0f,1.0f },{ 1.0f,1.0f },{ 1.0f,0.0f },{ 0.0f,0.0f }  // right
};

#endif CUBE_H
