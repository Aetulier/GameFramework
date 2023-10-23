require "Global"

local Ball = BaseClass("Ball", LuaUpdate)

function Ball:constructor(params)
    self.base = Ball.base
    print("Ball Constructor")
end

-- 重写父类
function Ball:Start( ... )
    print("Ball Start fun...")
     self.base:Start()
    -- 开启Update
    self:EnableUpdate(true)
    Ball.isUpdate = true
end

function Ball:Update()
    if Ball.isUpdate then
        print("ball update")
        
    end
end


return Ball
