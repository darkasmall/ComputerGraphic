#ifndef ROTATE_H
#define ROTATE_H

#include <vector>

struct Point {
	double x, y, z;
	Point(double x, double y, double z) {
		this->x = x;
		this->y = y;
		this->z = z;
	}
};

void rotate(double angle, double nx, double ny, double nz, std::vector <std::vector<Point>> &verges);

#endif ROTATE_H
