import random
import numpy as np

def main():
    # Xác định khoảng cách giữa các thành phố
    num_cities = 15
    # Tạo ma trận khoảng cách đối xứng
    distance_matrix = np.random.randint(1, 100, size=(num_cities, num_cities))
    distance_matrix = (distance_matrix + distance_matrix.T) // 2
    np.fill_diagonal(distance_matrix, 0)

    # Danh sách tên các thành phố
    city_names = [
        "Hà Nội", "TP.HCM", "Đà Nẵng", "Hải Phòng", "Nha Trang",
        "Cần Thơ", "Huế", "Vũng Tàu", "Đà Lạt", "Quy Nhơn",
        "Phan Thiết", "Hạ Long", "Sapa", "Mũi Né", "Cát Bà"
    ]

    def create_population(size):
        population = []
        for _ in range(size):
            individual = list(range(num_cities))
            random.shuffle(individual)
            population.append(individual)
        return population

    def calculate_distance(individual):
        distance = 0
        for i in range(len(individual) - 1):
            distance += distance_matrix[individual[i]][individual[i + 1]]
        distance += distance_matrix[individual[-1]][individual[0]]
        return distance

    def select_best(population):
        population.sort(key=calculate_distance)
        return population[:len(population) // 2]

    def crossover(parent1, parent2):
        # Sử dụng phương pháp Order Crossover (OX)
        size = len(parent1)
        start, end = sorted(random.sample(range(size), 2))
        
        # Lấy phần giữa từ parent1
        child = [-1] * size
        child[start:end] = parent1[start:end]
        
        # Điền các phần tử còn lại từ parent2
        remaining = [x for x in parent2 if x not in child[start:end]]
        j = 0
        for i in range(size):
            if child[i] == -1:
                child[i] = remaining[j]
                j += 1
        return child

    def mutate(individual):
        if random.random() < 0.2:  # Tăng tỉ lệ đột biến lên 20%
            # Đột biến 2-opt: Đảo ngược một đoạn con
            i, j = sorted(random.sample(range(len(individual)), 2))
            individual[i:j+1] = reversed(individual[i:j+1])
        return individual

    def genetic_algorithm(pop_size, generations):
        population = create_population(pop_size)
        best_distance = float('inf')
        best_solution = None
        generations_without_improvement = 0
        
        for gen in range(generations):
            best_individuals = select_best(population)
            current_best = best_individuals[0]
            current_distance = calculate_distance(current_best)
            
            if current_distance < best_distance:
                best_distance = current_distance
                best_solution = current_best.copy()
                generations_without_improvement = 0
                print(f"Thế hệ {gen}: Tìm thấy đường đi ngắn hơn với khoảng cách {best_distance}")
            else:
                generations_without_improvement += 1
            
            # Nếu không cải thiện sau 50 thế hệ, tăng tỉ lệ đột biến
            if generations_without_improvement > 50:
                population = create_population(pop_size // 2) + best_individuals
                generations_without_improvement = 0
                continue
                
            next_generation = best_individuals.copy()
            
            while len(next_generation) < pop_size:
                parent1, parent2 = random.sample(best_individuals, 2)
                child = crossover(parent1, parent2)
                child = mutate(child)
                next_generation.append(child)
            
            population = next_generation
            
        return best_solution

    # Chạy thuật toán với số lượng thế hệ và kích thước quần thể lớn hơn
    print("Đang tìm đường đi ngắn nhất...")
    best_route = genetic_algorithm(pop_size=200, generations=1000)
    best_city_names = [city_names[i] for i in best_route]
    
    print("\nKết quả cuối cùng:")
    print("Hành trình tốt nhất:", " -> ".join(best_city_names), "->", best_city_names[0])
    print("Tổng khoảng cách:", calculate_distance(best_route))

if __name__ == "__main__":
    main()
