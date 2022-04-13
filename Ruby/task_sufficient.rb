def factorial (number)
  puts (1..number).inject(1) { |product, n| product * n}
end

factorial(5)

class Integer
  def factorial
    if self < 0
      raise "Runtime error: cannot count factorial for negative number"
    else
      puts (1..self).inject(1) { |product, n| product * n}
    end
  end
end

5.factorial
# -1.factorial

module InstanceModule
  def square
    puts self * self
  end
end

class Integer
  include InstanceModule
end

5.square

module ClassModule
  def sample(size)
    if size < 0
      raise "ArgumentError: the number must be positive"
    else
      tab = Array.new(size)
      for int in tab
        int = rand(10)
        puts int
      end
    end
  end
end

class Integer
  extend ClassModule
end

Integer.sample(5)
# Integer.sample(-1)

