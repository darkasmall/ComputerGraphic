#include "Rotate.h"
#include <vector>

using namespace std;

const double PI = 3.14159;

double* multiplyVectorOnMatrix(double* vect, double** matr, int sz)
{
	double *answer = new double[sz];
	for (int i = 0; i < sz; i++)
	{
		double sum = 0;
		for (int j = 0; j < sz; j++)
		{
			sum += matr[j][i] * vect[j];
		}
		answer[i] = sum;
	}
	return answer;
}

void rotate(double angle, double nx, double ny, double nz, std::vector <std::vector<Point>> &verges) {
	angle = angle * PI / 180.0;
	double **matr = new double*[3];
	matr[0] = new double[3];
	matr[1] = new double[3];
	matr[2] = new double[3];
	matr[0][0] = nx * nx * (1 - cos(angle)) + cos(angle);
	matr[0][1] = nx * ny * (1 - cos(angle)) + nz * sin(angle);
	matr[0][2] = nx * nz * (1 - cos(angle)) - ny * sin(angle);

	matr[1][0] = nx * ny * (1 - cos(angle)) - nz * sin(angle);
	matr[1][1] = ny* ny*(1 - cos(angle)) + cos(angle);
	matr[1][2] = ny * nz * (1 - cos(angle)) + nx * sin(angle);

	matr[2][0] = nx * nz * (1 - cos(angle)) + ny * sin(angle);
	matr[2][1] = ny* nz*(1 - cos(angle)) - nx * sin(angle);
	matr[2][2] = nz * nz * (1 - cos(angle)) + cos(angle);

	for (int i = 0; i < verges.size(); i++) {
		for (int j = 0; j < verges[i].size(); j++) {
			double vect[] = { verges[i][j].x, verges[i][j].y, verges[i][j].z };
			double *ans = multiplyVectorOnMatrix(vect, matr, 3);
			verges[i][j].x = ans[0];
			verges[i][j].y = ans[1];
			verges[i][j].z = ans[2];
			delete ans;
		}
	}
}