namespace ME.BECS.Jobs {
    
    using static Cuts;
    using Unity.Jobs;
    using Unity.Jobs.LowLevel.Unsafe;
    using Unity.Collections.LowLevel.Unsafe;
    using Unity.Burst;

    [JobProducerType(typeof(JobAspectsComponentsExtensions8_3.JobProcess<,,,,,,,,,,,>))]
    public interface IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> : IJobForAspectsComponentsBase where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase {
        void Execute(in JobInfo jobInfo, in Ent ent, ref A0 a0,ref A1 a1,ref A2 a2,ref A3 a3,ref A4 a4,ref A5 a5,ref A6 a6,ref A7 a7, ref C0 c0,ref C1 c1,ref C2 c2);
    }

    public static unsafe partial class QueryAspectsComponentsScheduleExtensions8_3 {
        
        public static JobHandle Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(this QueryBuilder builder, in T job = default) where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase {
            builder.WithAspect<A0>(); builder.WithAspect<A1>(); builder.WithAspect<A2>(); builder.WithAspect<A3>(); builder.WithAspect<A4>(); builder.WithAspect<A5>(); builder.WithAspect<A6>(); builder.WithAspect<A7>();
            builder.With<C0>(); builder.With<C1>(); builder.With<C2>();
            builder.builderDependsOn = builder.SetEntities(builder.commandBuffer, builder.builderDependsOn);
            builder.builderDependsOn = job.Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(in builder.commandBuffer, builder.isUnsafe, builder.parallelForBatch, builder.scheduleMode, builder.builderDependsOn);
            builder.builderDependsOn = builder.Dispose(builder.builderDependsOn);
            return builder.builderDependsOn;
        }
        
        public static JobHandle Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(this Query staticQuery, in T job, in SystemContext context) where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase {
            return staticQuery.Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(in job, in context.world, context.dependsOn);
        }
        
        public static JobHandle Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(this Query staticQuery, in T job, in World world, JobHandle dependsOn = default) where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase {
            var state = world.state;
            var query = API.MakeStaticQuery(QueryContext.Create(state, world.id), dependsOn).FromQueryData(state, world.id, state->queries.GetPtr(state, staticQuery.id));
            return query.Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(in job);
        }

        public static JobHandle Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(this QueryBuilderDisposable staticQuery, in T job) where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase {
            staticQuery.builderDependsOn = job.Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(in staticQuery.commandBuffer, staticQuery.isUnsafe, staticQuery.parallelForBatch, staticQuery.scheduleMode, staticQuery.builderDependsOn);
            staticQuery.builderDependsOn = staticQuery.Dispose(staticQuery.builderDependsOn);
            return staticQuery.builderDependsOn;
        }
        
    }
    
    public static partial class EarlyInit {
        public static void DoAspectsComponents8_3<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>()
                where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect
                where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase
                where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> => JobAspectsComponentsExtensions8_3.JobEarlyInitialize<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>();
    }

    public static unsafe partial class JobAspectsComponentsExtensions8_3 {
        
        public static void JobEarlyInitialize<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>()
            where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect
            where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase
            where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> => JobProcess<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>.Initialize();

        public static JobHandle Schedule<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>(this T jobData, in CommandBuffer* buffer, bool unsafeMode, uint innerLoopBatchCount, ScheduleMode scheduleMode, JobHandle dependsOn = default)
            where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect
            where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase
            where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> {
            
            if (scheduleMode == ScheduleMode.Parallel) {
                
                //dependsOn = new StartParallelJob() {
                //                buffer = buffer,
                //            }.ScheduleSingle(dependsOn);
                            
                if (innerLoopBatchCount == 0u) innerLoopBatchCount = JobUtils.GetScheduleBatchCount(buffer->count);

            }
            
            buffer->sync = false;
            void* data = null;
            #if ENABLE_UNITY_COLLECTIONS_CHECKS && ENABLE_BECS_COLLECTIONS_CHECKS
            data = CompiledJobs<T>.Get(_address(ref jobData), buffer, unsafeMode, scheduleMode);
            var parameters = new JobsUtility.JobScheduleParameters(data, unsafeMode == true ? JobReflectionUnsafeData<T>.data.Data : JobReflectionData<T>.data.Data, dependsOn, scheduleMode);
            #else
            var dataVal = new JobData<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>() {
                scheduleMode = scheduleMode,
                jobData = jobData,
                buffer = buffer,
                a0 = buffer->state->aspectsStorage.Initialize<A0>(buffer->state),a1 = buffer->state->aspectsStorage.Initialize<A1>(buffer->state),a2 = buffer->state->aspectsStorage.Initialize<A2>(buffer->state),a3 = buffer->state->aspectsStorage.Initialize<A3>(buffer->state),a4 = buffer->state->aspectsStorage.Initialize<A4>(buffer->state),a5 = buffer->state->aspectsStorage.Initialize<A5>(buffer->state),a6 = buffer->state->aspectsStorage.Initialize<A6>(buffer->state),a7 = buffer->state->aspectsStorage.Initialize<A7>(buffer->state),
                c0 = buffer->state->components.GetRW<C0>(buffer->state, buffer->worldId),c1 = buffer->state->components.GetRW<C1>(buffer->state, buffer->worldId),c2 = buffer->state->components.GetRW<C2>(buffer->state, buffer->worldId),
            };
            data = _address(ref dataVal);
            var parameters = new JobsUtility.JobScheduleParameters(data, JobReflectionData<T>.data.Data, dependsOn, scheduleMode);
            #endif
            
            if (scheduleMode == ScheduleMode.Parallel) {
                return JobsUtility.ScheduleParallelForDeferArraySize(ref parameters, (int)innerLoopBatchCount, (byte*)buffer, null);
            }
            return JobsUtility.Schedule(ref parameters);
            
        }

        private struct JobData<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>
            where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect
            where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase
            where T : struct {
            public ScheduleMode scheduleMode;
            [NativeDisableUnsafePtrRestriction]
            public T jobData;
            [NativeDisableUnsafePtrRestriction]
            public CommandBuffer* buffer;
            public A0 a0;public A1 a1;public A2 a2;public A3 a3;public A4 a4;public A5 a5;public A6 a6;public A7 a7;
            public RefRW<C0> c0;public RefRW<C1> c1;public RefRW<C2> c2;
        }

        internal struct JobProcess<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>
            where A0 : unmanaged, IAspect where A1 : unmanaged, IAspect where A2 : unmanaged, IAspect where A3 : unmanaged, IAspect where A4 : unmanaged, IAspect where A5 : unmanaged, IAspect where A6 : unmanaged, IAspect where A7 : unmanaged, IAspect
            where C0 : unmanaged, IComponentBase where C1 : unmanaged, IComponentBase where C2 : unmanaged, IComponentBase
            where T : struct, IJobFor8Aspects3Components<A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> {

            [BurstDiscard]
            public static void Initialize() {
                if (JobReflectionData<T>.data.Data == System.IntPtr.Zero) {
                    #if ENABLE_UNITY_COLLECTIONS_CHECKS && ENABLE_BECS_COLLECTIONS_CHECKS
                    JobReflectionData<T>.data.Data = JobsUtility.CreateJobReflectionData(CompiledJobs<T>.GetJobType(false), typeof(T), (ExecuteJobFunction)Execute);
                    JobReflectionUnsafeData<T>.data.Data = JobsUtility.CreateJobReflectionData(CompiledJobs<T>.GetJobType(true), typeof(T), (ExecuteJobFunction)Execute);
                    #else
                    JobReflectionData<T>.data.Data = JobsUtility.CreateJobReflectionData(typeof(JobData<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2>), typeof(T), (ExecuteJobFunction)Execute);
                    #endif
                }
            }

            private delegate void ExecuteJobFunction(ref JobData<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> jobData, System.IntPtr bufferPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

            private static void Execute(ref JobData<T, A0,A1,A2,A3,A4,A5,A6,A7, C0,C1,C2> jobData, System.IntPtr bufferPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) {

                if (jobData.scheduleMode == ScheduleMode.Parallel) {
                    var jobInfo = JobInfo.Create(jobData.buffer->worldId);
                    jobInfo.count = jobData.buffer->count;
                    var aspect0 = jobData.a0;var aspect1 = jobData.a1;var aspect2 = jobData.a2;var aspect3 = jobData.a3;var aspect4 = jobData.a4;var aspect5 = jobData.a5;var aspect6 = jobData.a6;var aspect7 = jobData.a7;
                    while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out var begin, out var end) == true) {
                        jobData.buffer->BeginForEachRange((uint)begin, (uint)end);
                        for (uint i = (uint)begin; i < end; ++i) {
                            jobInfo.index = i;
                            var entId = *(jobData.buffer->entities + i);
                            var gen = Ents.GetGeneration(jobData.buffer->state, entId);
                            var ent = new Ent(entId, gen, jobData.buffer->worldId);
                            aspect0.ent = ent;aspect1.ent = ent;aspect2.ent = ent;aspect3.ent = ent;aspect4.ent = ent;aspect5.ent = ent;aspect6.ent = ent;aspect7.ent = ent;
                            jobData.jobData.Execute(in jobInfo, in ent, ref aspect0,ref aspect1,ref aspect2,ref aspect3,ref aspect4,ref aspect5,ref aspect6,ref aspect7, ref jobData.c0.Get(ent.id, ent.gen),ref jobData.c1.Get(ent.id, ent.gen),ref jobData.c2.Get(ent.id, ent.gen));
                        }
                        jobData.buffer->EndForEachRange();
                    }
                } else {
                    var jobInfo = JobInfo.Create(jobData.buffer->worldId);
                    jobInfo.count = jobData.buffer->count;
                    JobUtils.SetCurrentThreadAsSingle(true);
                    var aspect0 = jobData.a0;var aspect1 = jobData.a1;var aspect2 = jobData.a2;var aspect3 = jobData.a3;var aspect4 = jobData.a4;var aspect5 = jobData.a5;var aspect6 = jobData.a6;var aspect7 = jobData.a7;
                    jobData.buffer->BeginForEachRange(0u, jobData.buffer->count);
                    for (uint i = 0u; i < jobData.buffer->count; ++i) {
                        jobInfo.index = i;
                        var entId = *(jobData.buffer->entities + i);
                        var gen = Ents.GetGeneration(jobData.buffer->state, entId);
                        var ent = new Ent(entId, gen, jobData.buffer->worldId);
                        aspect0.ent = ent;aspect1.ent = ent;aspect2.ent = ent;aspect3.ent = ent;aspect4.ent = ent;aspect5.ent = ent;aspect6.ent = ent;aspect7.ent = ent;
                        jobData.jobData.Execute(in jobInfo, in ent, ref aspect0,ref aspect1,ref aspect2,ref aspect3,ref aspect4,ref aspect5,ref aspect6,ref aspect7, ref jobData.c0.Get(ent.id, ent.gen),ref jobData.c1.Get(ent.id, ent.gen),ref jobData.c2.Get(ent.id, ent.gen));
                    }
                    jobData.buffer->EndForEachRange();
                    JobUtils.SetCurrentThreadAsSingle(false);
                }
                
            }
        }
    }
    
}