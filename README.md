# BritoWorks Core

**BritoWorks Core** is a lightweight Unity utility package providing math helpers, vector constructors, swizzle-style extensions, and performance-oriented spatial operations.

It is designed for reuse across gameplay, AI, and simulation code, with an emphasis on clarity, predictability, and zero unnecessary overhead.

Targeted and tested against **Unity 6000.3.2f1**.

---

## Features

### Vector Constructors

GLSL-inspired helpers for concise vector creation.

```csharp
var a = vec2(1f);
var b = vec3(1f, 2f, 3f);
var c = vec4(b, 1f);
```

---

### Swizzle Extensions

Common swizzle patterns for `Vector2`, `Vector3`, and `Vector4`.

```csharp
Vector2 xy = v3.xy();
Vector3 xxx = v2.xxx();
Vector2 yy = v4.yy();
```

---

### Fast Distance & Range Checks

Manual math implementations to avoid temporary allocations and operator overhead.

```csharp
if (a.inRange(b, 10f))
{
	// within range
}

float d2 = a.distanceSquared(b);
```

---

### Direction Helpers

Normalized direction vectors with zero-length safety checks.

```csharp
Vector3 dir = transform.dir(targetPosition);
Vector2 dir2D = position2D.dir(otherTransform);
```

---

### Math Wrappers

Thin wrappers over `Unity.Mathematics.math` for consistency and readability.

```csharp
float r = deg2rad(90f);
bool same = approx(a, b, 0.001f);
```

---

## Included Types

### `BritoBehavior`

A base `MonoBehaviour` providing:

- Cached transform accessors (`position`, `forward`, `up`, etc.)
- Vector constructors (`vec2`, `vec3`, `vec4`)
- Math helpers (`sin`, `cos`, `sqrt`, `deg2rad`, etc.)

This class is intended as a convenience base, not a framework.

---

## Author

**Min Jun Kim**  
Britoshi
